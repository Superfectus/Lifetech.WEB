using Lifetech.Models;

namespace Lifetech.Business;

public interface IMailBusiness
{
    MailResponseModel SendMail(MailRequestModel mailRequestModel);
}