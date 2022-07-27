using Microsoft.AspNetCore.Mvc.Rendering;
using Mvc.Data;
using Mvc.Models;
using Mvc.Util;
using System.Collections.Generic;


namespace Mvc.ViewModels
{
    public class GuitarBuilderViewModel
    {
        public GuitarBuilderViewModel()
        {
            PopulateFromInventory();
            Guitar = new();
        }


        public Guitar Guitar { get; set; }

        public IEnumerable<SelectListItem> BridgePickupList { get; set; }

        public string SelectedBridgePickup { get; set; }

        public IEnumerable<SelectListItem> MiddlePickupList { get; set; }

        public string SelectedMiddlePickup { get; set; }

        public IEnumerable<SelectListItem> NeckPickupList { get; set; }

        public string SelectedNeckPickup { get; set; }

        public IEnumerable<SelectListItem> BodyList { get; set; }

        public string SelectedBody { get; set; }

        public IEnumerable<SelectListItem> StringsList { get; set; }

        public IEnumerable<string> SelectedStrings { get; set; }

        internal Inventory Inventory { get; private set; }

        private void PopulateFromInventory()
        {
            Inventory = new();

            BodyList = SelectListItemAdapter.ConvertToSelectListItemCollection(Inventory.GuitarBodies, s => s.Name);

            BridgePickupList = SelectListItemAdapter.ConvertToSelectListItemCollection(Inventory.GuitarPickups, s => s.Name);

            MiddlePickupList = SelectListItemAdapter.ConvertToSelectListItemCollection(Inventory.GuitarPickups, s => s.Name);

            NeckPickupList = SelectListItemAdapter.ConvertToSelectListItemCollection(Inventory.GuitarPickups, s => s.Name);

            StringsList = SelectListItemAdapter.ConvertToSelectListItemCollection(Inventory.GuitarStrings, s => s.Name);
        }
    }
}
