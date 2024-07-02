using System.ComponentModel.DataAnnotations;

namespace testTask.Models;

public class Order
{
    public Order(string senderCity, string senderAddress, string receiverCity, string receiverAddress,
        double orderWeight, DateTime orderReceiveTime)
    {
        Id = new Guid();
        SenderCity = senderCity;
        SenderAddress = senderAddress;
        ReceiverCity = receiverCity;
        ReceiverAddress = receiverAddress;
        OrderWeight = orderWeight;
        OrderReceiveTime = DateTime.SpecifyKind(orderReceiveTime, DateTimeKind.Utc);
    }

    public Order()
    {
    }

    [Key] public Guid Id { get; set; }

    [Required] public string SenderCity { get; set; }
    [Required] public string SenderAddress { get; set; }
    [Required] public string ReceiverCity { get; set; }
    [Required] public string ReceiverAddress { get; set; }
    [Required] public double OrderWeight { get; set; }

    [Required] public DateTime OrderReceiveTime { get; set; }
}