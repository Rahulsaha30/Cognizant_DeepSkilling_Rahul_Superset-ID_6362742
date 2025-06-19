using System;

public interface MainNotification
{
    void Notify();
}

public class Email : MainNotification
{
    public void Notify()
    {
        Console.WriteLine("To Email");
    }
}

public class SMS : MainNotification
{
    public void Notify()
    {
        Console.WriteLine("To SMS");
    }
}


public abstract class NotificationCreator
{
    public abstract MainNotification CreateNotification();
}


public class EmailCreator : NotificationCreator
{
    public override MainNotification CreateNotification()
    {
        return new Email();
    }
}


public class SMSCreator : NotificationCreator
{
    public override MainNotification CreateNotification()
    {
        return new SMS();
    }
}

class Program
{
    static void Main()
    {
        NotificationCreator creator;

        creator = new EmailCreator();
        MainNotification email = creator.CreateNotification();
        email.Notify();  

        creator = new SMSCreator();
        MainNotification sms = creator.CreateNotification();
        sms.Notify();    
    }
}
