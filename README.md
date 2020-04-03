# DealLocator
DealLocator

Location aware applicaiton for finding deals that are within the mobile geofence surronding a users device. The system is comprised of a Xamarin.Forms app, Asp.netcore API and a Asp.netcore MVC application. 

Asp.netcore MVC app and Asp.netcore API hosted on Azure along with the SQL Server database.

The Geo mapping logic uses the API to communciate with Azure Map Service but
is render in native map on the Android device.

Authentication and Authorization is handled by the AzureB2C service
