using HtmlAgilityPack;
using Models;
using Models.Grabber;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Parser
{
   public class ResultParser
    {
        private const string leftBracket = "u003c";
        private const string rightBracket = "u003e";

        public List<PenaltyRecord> ParseResult(string rawResult)
        {
            List<PenaltyRecord> result = new List<PenaltyRecord>();

            if(rawResult.Contains("По заданным критериям поиска информация не найдена"))
            {
                return result;
            }

            var htmlDoc = new HtmlDocument();
            var parsedResult = rawResult.Replace("\\", "").Replace("\"\"", "").Replace(leftBracket, "<").Replace(rightBracket, ">").Replace("rn", "");
            parsedResult = @"<!DOCTYPE html>
                                <html>
                                <body>" + parsedResult;
            parsedResult += @"</body></html>";

            htmlDoc.LoadHtml(parsedResult);

            var tableBody = htmlDoc.DocumentNode.SelectNodes("//tr");
            tableBody.Remove(0); // Table header

            for(var i = 0; i < tableBody.Count; i++)
            {
                var fields = tableBody[i].InnerText.Split("  ");
                fields = fields.Where(item => item != "").ToArray();
                var model = new PenaltyRecord()
                {
                    FullName = fields[0],
                    CertificateSeries = fields[1],
                    CertificateNumber = fields[2],
                    PenaltyDataTime = DateTime.Parse(fields[3]),
                    PenaltyNumber = fields[4],
                };
                result.Add(model);
            }

            return result;
        }
    }
}
