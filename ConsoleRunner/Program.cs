using Grabber;
using Models.CarInfo;
using Parser;
using System;

namespace ConsoleRunner
{
    class Program
    {
        public static void Main(string[] args)
        {
            var grabber = new MVDGrabber();
            var data = new CarIdCardData()
            {
                FullName = "ДАКУКО ЕКАТЕРИНА МИХАЙЛОВНА",
                CertificateSeries = "МАА",
                CertificateNumber = "1741248",
            };
            //{
            //    FullName = "ДЕРИД НАТАЛЬЯ АНТОНОВНА",
            //    CertificateSeries = "АВА",
            //    CertificateNumber = "137072",
            //};
            //{
            //    FullName = "БОГОСЛОВ ОЛЬГА АЛЕКСАНДРОВНА",
            //    CertificateSeries = "МАА",
            //    CertificateNumber = "1956099",
            //};

            var rawResult = grabber.GetRawData(data);

            var parsed = new ResultParser();

            var parsedItems = parsed.ParseResult(rawResult);

            Console.WriteLine($"{data.FullName} {data.CertificateSeries}{data.CertificateNumber}");

            if (parsedItems.Count == 0)
            {
                Console.WriteLine("NO RESULT");
            }

            parsedItems.ForEach(item =>
            {
                Console.WriteLine($"{item.PenaltyDataTime}| №{item.PenaltyNumber}");
            });

            Console.ReadLine();
        }
    }
}
