using Aliyun.Acs.Core;
using Aliyun.Acs.Core.Profile;
using CertbotAliyunDns;
using System;
using System.Text;

Console.OutputEncoding = Encoding.UTF8;

if (args.Length < 3)
{
	Console.WriteLine(@"Wrong args!");
	return 1;
}

const string certbotDomainVariableName = @"CERTBOT_DOMAIN";
const string certbotValidationVariableName = @"CERTBOT_VALIDATION";

var accessKeyId = args[1];
var accessKeySecret = args[2];

var profile = DefaultProfile.GetProfile(@"cn-shanghai", accessKeyId, accessKeySecret);
var client = new DefaultAcsClient(profile);

switch (args[0])
{
	case @"add":
	{
		var domain = Environment.GetEnvironmentVariable(certbotDomainVariableName);
		var validation = Environment.GetEnvironmentVariable(certbotValidationVariableName);

		if (domain is null || validation is null)
		{
			Console.WriteLine($@"Cannot get {certbotDomainVariableName} or {certbotValidationVariableName}");
			return 1;
		}

		Console.WriteLine($@"Domain: {domain}");
		Console.WriteLine($@"Validation: {validation}");

		Console.WriteLine(@"Adding record...");
		client.AddCertbotValidation(domain, validation);

		break;
	}
	case @"delete":
	{
		var domain = Environment.GetEnvironmentVariable(certbotDomainVariableName);
		if (domain is null)
		{
			Console.WriteLine($@"Cannot get {certbotDomainVariableName}");
			return 1;
		}

		Console.WriteLine(@"Deleting record...");
		client.DeleteCertbotValidation(domain);

		break;
	}
	default:
	{
		Console.WriteLine(@"Wrong args!");
		return 1;
	}
}

return 0;
