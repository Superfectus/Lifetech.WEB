using Lifetech.Business;
using Lifetech.Models;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Lifetech.Controllers

{
    [ApiController]
    [Route("[controller]")]
    public class MailController : Controller
    {  
        private readonly AppDbContext _context;
        private readonly IMailBusiness _mailBusiness;
        public MailController(IMailBusiness mailBusiness,AppDbContext context)
        {
            _context=context;
            
            _mailBusiness = mailBusiness;
        }

     


        [HttpPost("SendFormMail")]
        [SwaggerOperation(
            Summary = "Mail gönderir",
            Description = "Mail gönderir")]
        [Route("Contact", Name = "Contact")]
   
        //   _context.Emails.Add();
        //_context.SaveChanges(Emails);

        public MailResponseModel SendFormMail([FromBody] MailRequestModel mailRequestModel)
        {
            var response = _mailBusiness.SendMail(mailRequestModel);
            return (response);
        }
    }
}   