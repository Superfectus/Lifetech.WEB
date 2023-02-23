using Lifetech.WEB.Models;

namespace Lifetech.WEB.Business;

public interface IMailBusiness
{
    MailResponseModel SendMail(MailRequestModel mailRequestModel);
}