using Aliyun.Acs.Alidns.Model.V20150109;
using Aliyun.Acs.Core;
using Aliyun.Acs.Core.Exceptions;
using System;

namespace CertbotAliyunDns
{
	internal static class AliyunClientExtensions
	{
		public static void AddCertbotValidation(this DefaultAcsClient client, string domain, string validation)
		{
			try
			{
				var request = new AddDomainRecordRequest
				{
					DomainName = domain,
					RR = @"_acme-challenge",
					Type = @"TXT",
					_Value = validation
				};

				var response = client.GetAcsResponse(request);

				Console.WriteLine($@"RecordId: {response.RecordId}");
				Console.WriteLine($@"RequestId: {response.RequestId}");
			}
			catch (ServerException e)
			{
				Console.WriteLine(e);
			}
			catch (ClientException e)
			{
				Console.WriteLine(e);
			}
		}

		public static void DeleteCertbotValidation(this DefaultAcsClient client, string domain)
		{
			try
			{
				var request = new DeleteSubDomainRecordsRequest
				{
					DomainName = domain,
					RR = @"_acme-challenge",
					Type = @"TXT"
				};

				var response = client.GetAcsResponse(request);

				Console.WriteLine($@"RR: {response.RR}");
				Console.WriteLine($@"RequestId: {response.RequestId}");
				Console.WriteLine($@"TotalCount: {response.TotalCount}");
			}
			catch (ServerException e)
			{
				Console.WriteLine(e);
			}
			catch (ClientException e)
			{
				Console.WriteLine(e);
			}
		}
	}
}
