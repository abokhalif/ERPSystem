using ReceiptsSystem.Models;

namespace ReceiptsSystem.ViewModels;

public class ReceiptViewModel
{
    public Receipt Receipt { get; set; }
    public List<Item> Items { get; set; }
    public ReceiptItem ReceiptItem { get; set; }
}
