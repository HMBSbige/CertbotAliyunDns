using Aliyun.Acs.Core;
using Aliyun.Acs.Core.Profile;
using CertbotAliyunDns;
using System.Text;

Console.OutputEncoding = Encoding.UTF8;

if (args.Length < 3)
{
	Console.WriteLine(@"Wrong args!");
	return 1;
}

const string certbotDomainVariableName = @"CERTBOT_DOMAIN";
const string certbotValidationVariableName = @"CERTBOT_VALIDATION";

string accessKeyId = args[1];
string accessKeySecret = args[2];

DefaultProfile? profile = DefaultProfile.GetProfile(@"cn-shanghai", accessKeyId, accessKeySecret);
DefaultAcsClient client = new(profile);

switch (args[0])
{
	case @"add":
	{
		string? domain = Environment.GetEnvironmentVariable(certbotDomainVariableName);
		string? validation = Environment.GetEnvironmentVariable(certbotValidationVariableName);

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
		string? domain = Environment.GetEnvironmentVariable(certbotDomainVariableName);
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
