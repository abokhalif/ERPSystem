using Microsoft.AspNetCore.Mvc;
using ReceiptsSystem.Models;
using ReceiptsSystem.ViewModels;

namespace ReceiptsSystem.Controllers
{
    public class ReceiptController : Controller
    {
        [HttpGet]
        public IActionResult Create()
        {
            var viewModel = new ReceiptViewModel
            {
                Receipt = new Receipt { CreatedAt = DateTime.Now },
                Items = new List<Item>()
            };
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult AddItem(ReceiptViewModel viewModel)
        {
            // Calculate item amount and update total amount
            var itemAmount = viewModel.Items.Single(i => i.ItemID == viewModel.ReceiptItem.ItemID).Price * viewModel.ReceiptItem.Quantity;
            viewModel.Receipt.TotalAmount += itemAmount;

            // Add item to receipt
            viewModel.Receipt.ReceiptItems.Add(new ReceiptItem
            {
                ItemID = viewModel.ReceiptItem.ItemID,
                Quantity = viewModel.ReceiptItem.Quantity
            });

            return View("Create", viewModel);
        }

        [HttpPost]
        public IActionResult EnterPaidAmount(ReceiptViewModel viewModel)
        {
            viewModel.Receipt.RemainingAmount = viewModel.Receipt.TotalAmount - viewModel.Receipt.PaidAmount;
            return View("Create", viewModel);
        }

        [HttpPost]
        public IActionResult CreateReceipt(ReceiptViewModel viewModel)
        {
            // Save receipt and its items to the database
            // Example:
            // _context.Receipts.Add(viewModel.Receipt);
            // _context.SaveChanges();

            return RedirectToAction("Index", "Home"); // Redirect to home or another appropriate action
        }
    }
    }