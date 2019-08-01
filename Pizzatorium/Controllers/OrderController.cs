using Pizzatorium.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Pizzatorium.Controllers
{
    public class OrderController : Controller
    {
        private StoreDBContext context = new StoreDBContext();

        // Design : GET
        public ActionResult Design()
        {
            if ((string)Session["Username"] == "")
            {
                return RedirectToAction("Index", "Account");
            }
            else
            {
                Session["Pizza"] = "";
                Session["Ingredients"] = "";
                Session["Total"] = "";
                ViewBag.PizzaSizes = PizzaSizes(null);
                List<SelectListItem> ingredientShows = new List<SelectListItem>();
                foreach (var item in context.Ingredients)
                {
                    ingredientShows.Add(new SelectListItem() { Text = item.dIngredient, Value = item.IngredientId.ToString() });
                }
                ViewBag.TotalDrop = ingredientShows.Count();
                ViewBag.IngredientSelect = ingredientShows;

                return View();
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Design([Bind(Include = "form,IngredientSelect")] DesignClass design)
        {
            if (ModelState.IsValid)
            {
                string pizza = "1";
                foreach (var item in design.form)
                {
                    pizza = item.ToString();
                }
                var list = context.Ingredients.ToList();
                string pizzaSize = SelectedPizzaSize(pizza);

                Session["Pizza"] = pizzaSize;

                foreach (var item in design.IngredientSelect)
                {
                    Session["Ingredients"] += SelectedIngredientsName(item) + " ";
                }
                decimal Total = SelectedPizzaPrice(pizzaSize);
                decimal TotalIngredient = 0;
                foreach (var item in design.IngredientSelect)
                {
                    TotalIngredient += SelectedIngredientsPrice(item);
                }
                //Session["TotalIngredient"] = TotalIngredient;
                if (TotalIngredient == 0)
                {
                    Session["Error"] = "Error";
                    return RedirectToAction("Design", "Order");
                }
                else
                {
                    Total += TotalIngredient;
                    Session["Total"] = Total;
                    return RedirectToAction("Final");
                }
            }
            ViewBag.PizzaSizes = PizzaSizes(null);
            List<SelectListItem> ingredientShows = new List<SelectListItem>();
            foreach (var item in context.Ingredients)
            {
                ingredientShows.Add(new SelectListItem() { Text = item.dIngredient, Value = item.IngredientId.ToString() });
            }
            ViewBag.TotalDrop = ingredientShows.Count();
            ViewBag.IngredientSelect = ingredientShows;
            return View();
        }


        // Final : GET
        public ActionResult Final()
        {
            if ((string)Session["Username"] == "")
            {
                return RedirectToAction("Index", "Account");
            }
            else
            {
                ViewBag.pizza = Session["Pizza"];
                ViewBag.Ingredients = Session["Ingredients"];
                ViewBag.Total = Session["Total"];
                ViewBag.getTest = Session["GetTest"];
                ViewBag.Payment = PaymentMethods(null);

                List<SelectListItem> deliveries = new List<SelectListItem>();
                foreach (var item in context.Deliveries)
                {
                    deliveries.Add(new SelectListItem() { Value = item.DeliveryId.ToString(), Text = item.dArea });
                }
                ViewBag.DeliveriesList = deliveries;
                return View();
            }
        }

        [HttpPost]
        public ActionResult Final(FormCollection form)
        {
            Session["Reciept"] = $"{(string)Session["Pizza"]} {(string)Session["Ingredients"]} - Pizza";
            Session["Payment"] = form["Payment"];
            Session["Area"] = form["DeliveriesList"];
            if ((string)Session["Area"] == "")
            {
                Session["PaymenetError"] = "Error";
                return RedirectToAction("Final", "Order");
            }
            else
            {
                Session["Address"] = form["AddressLine"];
                return RedirectToAction("ThankYou");
            }
        }


        // ThankYou : GET
        public ActionResult ThankYou()
        {
            if ((string)Session["Username"] == "")
            {
                return RedirectToAction("Index", "Account");
            }
            else
            {
                ViewBag.Reciept = (string)Session["Reciept"];
                ViewBag.Total = Session["Total"];
                ViewBag.DeliveryPerson = SelectedDilveryPerson(Session["Area"].ToString());
                ViewBag.ImagePath = ReturnImage(Session["Area"].ToString());
                try
                {
                    ViewBag.PaymentChosen = PaymentSelected(Session["Payment"].ToString());
                }
                catch (System.Exception)
                {
                    Session["NoPayment"] = "Error";
                    return RedirectToAction("Final", "Order");
                }
                ViewBag.Area = SelectedArea(Session["Area"].ToString());
                ViewBag.AddressGiven = Session["Address"];
                return View();
            }
        }

        // METHOD : GET

        private SelectList PizzaSizes(string[] selected)
        {
            List<PizzaSize> pizzaSizes = new List<PizzaSize>()
            {
                new PizzaSize(){ID = 1, PizzaSizes = "Small"},
                new PizzaSize(){ID = 2, PizzaSizes = "Medium"},
                new PizzaSize(){ID = 3, PizzaSizes = "Large"}
            };
            return new SelectList(pizzaSizes, "ID", "PizzaSizes", selected);
        }

        private string SelectedPizzaSize(string value)
        {
            if (value == "1")
                return "Small";
            else if (value == "2")
                return "Medium";
            else
                return "Large";
        }

        private decimal SelectedPizzaPrice(string selected)
        {
            if (selected == "Small")
                return 15;
            else if (selected == "Medium")
                return 25;
            else
                return 40;
        }

        private string SelectedIngredientsName(int selected)
        {
            var Names = from cont in context.Ingredients where cont.IngredientId == selected select cont;
            string returnNames = "";
            foreach (var item in Names)
            {
                returnNames += item.dIngredient.ToString() + " , ";
            }
            return returnNames;
        }

        private decimal SelectedIngredientsPrice(int selected)
        {
            var Price = from cont in context.Ingredients where cont.IngredientId == selected select cont.dPrice;
            decimal returnAmount = 0;
            foreach (var item in Price)
            {
                returnAmount += item; 
            }
                return returnAmount;
        }
        
        private MultiSelectList PaymentMethods(string[] value)
        {
            List<Payment> payments = new List<Payment>()
            {
                new Payment(){ID = 1, MethodName = "EFT"},
                new Payment(){ID = 2, MethodName = "Cash"},
                new Payment(){ID = 3, MethodName = "Credit Card"}
            };
            return new MultiSelectList(payments, "ID", "MethodName", value);
        }

        private string PaymentSelected(string selected)
        {
            List<Payment> payments = new List<Payment>()
            {
                new Payment(){ID = 1, MethodName = "EFT"},
                new Payment(){ID = 2, MethodName = "Cash"},
                new Payment(){ID = 3, MethodName = "Credit Card"}
            };
            var selectedMethod = from slc in payments where slc.ID == int.Parse(selected) select slc.MethodName;
            string method = "";
            foreach (var item in selectedMethod)
            {
                method = item;
            }
            if (method == "")
            {
                return "Cash";
            }
            else
            {
                return method;
            }
        }

        private string SelectedArea(string selected)
        {
            int selectedValue = int.Parse(selected);
            var area = from cont in context.Deliveries where cont.DeliveryId == selectedValue select cont.dArea;
            string returnArea = "";
            foreach (var item in area)
            {
                returnArea = item;
            }
            return returnArea;
        }

        private string SelectedDilveryPerson(string selected)
        {
            var person = from cont in context.Deliveries where cont.DeliveryId.ToString() == selected select cont;
            string returnPerson = "";
            foreach (var item in person)
            {
                returnPerson = item.dName + " to area " + item.dArea;
            }
            return returnPerson;
        }

        private string ReturnImage(string selected)
        {
            string returnUrl = "";
            try
            {
                int selectedValue = int.Parse(selected);
                var img = from cont in context.Deliveries where cont.DeliveryId == selectedValue select cont;
                foreach (var item in img)
                {
                    returnUrl = item.dPhoto;
                }
            }
            catch (System.Exception)
            {
                Session["PaymenetError"] = "Error";
                RedirectToAction("Final", "Order");
            }
            return returnUrl;

        }
    }
}