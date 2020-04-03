using Android.Content;
using Android.Gms.Maps;
using Android.Gms.Maps.Model;
using Android.Widget;
using DealLocator.Mobile.Droid;
using DealLocator.Mobile;
using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Xamarin.Forms.Maps.Android;
using Xamarin.Forms.Platform.Android;
using DealLocator.Mobile.Models;

[assembly: ExportRenderer(typeof(CustomMap), typeof(CustomMapRenderer))]

namespace DealLocator.Mobile.Droid
{
    public class CustomMapRenderer : MapRenderer, GoogleMap.IInfoWindowAdapter
    {
        //     List<Pin> Pins;
        Map formsMap;
        public CustomMapRenderer(Context context) : base(context)
        {
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Map> e)
        {
            base.OnElementChanged(e);



            if (e.NewElement != null)
            {
                formsMap = new Map();
               formsMap = e.NewElement;
                //Pins = formsMap.Pins;
                Control.GetMapAsync(this);
            }
            
        }

       

        protected override void OnMapReady(GoogleMap map)
        {
            base.OnMapReady(map);
            NativeMap.SetInfoWindowAdapter(this);
        }

        /// <summary>
        /// creates the pin instance and sets its data
        /// </summary>
        /// <param name="pin"></param>
        /// <returns></returns>
        protected override MarkerOptions CreateMarker(Pin pin)
        {
            var marker = new MarkerOptions();
            marker.SetPosition(new LatLng(pin.Position.Latitude, pin.Position.Longitude));
            marker.SetTitle(pin.Label);
            marker.SetSnippet(pin.Address);

            return marker;
        }




        public Android.Views.View GetInfoContents(Marker marker)
        {
            var inflater = Android.App.Application.Context.GetSystemService(Context.LayoutInflaterService) as Android.Views.LayoutInflater;
            if (inflater != null)
            {
                Android.Views.View view;

                var customPin = GetCustomPin(marker);
                if (customPin == null)
                {
                    throw new Exception("Custom pin not found");
                }

                view = inflater.Inflate(Resource.Layout.MapInfoWindow, null);


                var infoTitle = view.FindViewById<TextView>(Resource.Id.InfoWindowTitle);
                var infoSubtitle = view.FindViewById<TextView>(Resource.Id.InfoWindowSubtitle);
               
 
                if (infoTitle != null)
                {
                    infoTitle.Text = marker.Title;
                }

                if (infoSubtitle != null)
                {
                    infoSubtitle.Text = marker.Snippet;
                }
                return view;

            }
            return null;
        }

        public Android.Views.View GetInfoWindow(Marker marker)
        {
            return null;
        }

        
        Pin GetCustomPin(Marker annotation)
        {
            var position = new Position(annotation.Position.Latitude, annotation.Position.Longitude);
            foreach (var pin in formsMap.Pins)
            {
                if (pin.Position == position)
                {
                    return pin;
                }
            }
            return null;
        }


    }
}