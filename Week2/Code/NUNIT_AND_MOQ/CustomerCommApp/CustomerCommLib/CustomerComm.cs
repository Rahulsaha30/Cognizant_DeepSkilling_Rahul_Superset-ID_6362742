namespace CustomerCommLib
{
    public class CustomerComm
    {
        private readonly IMailSender _mailSender;

        public CustomerComm(IMailSender mailSender)
        {
            _mailSender = mailSender;
        }

        public bool SendMailToCustomer()
        {
            string address = "cust123@abc.com";
            string message = "Some Message";

            return _mailSender.SendMail(address, message);
        }
    }
}
