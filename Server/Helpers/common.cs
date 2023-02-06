using System;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace Server.Helpers
{
    public class GeoLocationData
    {
        public double latitude { get; set; }
        public double longitude { get; set; }

    }
    public class common
    {
        //:::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
        //::  This function converts decimal degrees to radians             :::
        //:::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
        private static double deg2rad(double deg)
        {
            return (deg * Math.PI / 180.0);
        }

        //:::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
        //::  This function converts radians to decimal degrees             :::
        //:::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
        private static double rad2deg(double rad)
        {
            return (rad / Math.PI * 180.0);
        }
        public static double distance(double lat1, double lon1, double lat2, double lon2, char unit)
        {
            if ((lat1 == lat2) && (lon1 == lon2))
            {
                return 0;
            }
            else
            {
                double theta = lon1 - lon2;
                double dist = Math.Sin(deg2rad(lat1)) * Math.Sin(deg2rad(lat2)) + Math.Cos(deg2rad(lat1)) * Math.Cos(deg2rad(lat2)) * Math.Cos(deg2rad(theta));
                dist = Math.Acos(dist);
                dist = rad2deg(dist);
                dist = dist * 60 * 1.1515;
                if (unit == 'K')
                {
                    dist = dist * 1.609344;
                }
                else if (unit == 'N')
                {
                    dist = dist * 0.8684;
                }
                return (dist);
            }
        }

        // public static double DistanceTo(double lat1, double lon1, double lat2, double lon2, char unit = 'K')
        // {
        //     double rlat1 = Math.PI * lat1 / 180;
        //     double rlat2 = Math.PI * lat2 / 180;
        //     double theta = lon1 - lon2;
        //     double rtheta = Math.PI * theta / 180;
        //     double dist =
        //         Math.Sin(rlat1) * Math.Sin(rlat2) + Math.Cos(rlat1) *
        //         Math.Cos(rlat2) * Math.Cos(rtheta);
        //     dist = Math.Acos(dist);
        //     dist = dist * 180 / Math.PI;
        //     dist = dist * 60 * 1.1515;

        //     switch (unit)
        //     {
        //         case 'K': //Kilometers -> default
        //             return dist * 1.609344;
        //         case 'N': //Nautical Miles 
        //             return dist * 0.8684;
        //         case 'M': //Miles
        //             return dist;
        //     }

        //     return dist;
        // }
        public async Task<string> uploadfile(IFormFile file, ILogger _logger)
        {
            string _fileName = string.Empty;
            try
            {
                if (file.Length > 0)
                {
                    var uploadDirecotroy = "uploads\\";
                    var uploadPath = Path.Combine(Directory.GetCurrentDirectory(), uploadDirecotroy);
                    _logger.LogError($"uploadPath={uploadPath}");

                    if (!Directory.Exists(uploadPath))
                        Directory.CreateDirectory(uploadPath);

                    var fileName = Guid.NewGuid() + Path.GetExtension(file.FileName);
                    var filePath = Path.Combine(Directory.GetCurrentDirectory(), uploadDirecotroy, fileName);

                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        await file.CopyToAsync(fileStream);
                        _fileName = fileName;
                    }

                }
                else
                {
                    _logger.LogError($"no file is uploaded");
                }

            }
            catch (System.Exception ex)
            {
                _logger.LogError($"Error happend at {ex.Message}");
                _fileName = string.Empty;

            }
            return _fileName;

        }

        public async Task<GeoLocationData> GetGeoLocation(string address)
        {
            var geo = new GeoLocationData();


            try
            {
                string key = "AIzaSyB-BqCGBS_uuXsZI57LWEL5iJAN8PTnPF8";
                var url = string.Format("https://maps.googleapis.com/maps/api/geocode/json?address={0}&key={1}", address, key);
                var req = (HttpWebRequest)WebRequest.Create(url);

                var res = (HttpWebResponse)req.GetResponse();

                using (var streamreader = new StreamReader(res.GetResponseStream()))
                {
                    var result = await streamreader.ReadToEndAsync();
                    if (!string.IsNullOrWhiteSpace(result))
                    {
                        dynamic root = JsonConvert.DeserializeObject(result);

                        if (root.status == "OK")
                        {

                            geo.latitude = root.results[0].geometry.location.lat;
                            geo.longitude = root.results[0].geometry.location.lng;


                        }
                    }
                    else
                    {

                        geo.latitude = 0;
                        geo.longitude = 0;
                    }
                }
                return geo;

            }
            catch (System.Exception)
            {
                geo.latitude = 0;
                geo.longitude = 0;
                return geo;
            }
        }

    }
}