using Mvc.Data;
using Mvc.Models;
using System;
using System.Linq;


namespace Mvc.ViewModels
{
    public class GuitarBuilderToGuitarAdapter
    {
        public Guitar BuildGuitar(GuitarBuilderViewModel viewModel)
        {
            return viewModel == null ? null : new Guitar
            {
                Name = viewModel.Guitar.Name,
                BridgePickup = SelectPickup(viewModel.Inventory, viewModel.SelectedBridgePickup),
                MiddlePickup = SelectPickup(viewModel.Inventory, viewModel.SelectedMiddlePickup),
                NeckPickup = SelectPickup(viewModel.Inventory, viewModel.SelectedNeckPickup),
                Body = viewModel.Inventory?.GuitarBodies?.FirstOrDefault(b => b.Name == viewModel.SelectedBody),
                Strings = (from gs in viewModel.Inventory.GuitarStrings
                           where viewModel.SelectedStrings != null
                           && viewModel.SelectedStrings.Contains(gs.Name)
                           select gs).ToList(),
            };
        }

        private GuitarPickup SelectPickup(Inventory inventory, string pickupName)
        {
            return string.IsNullOrEmpty(pickupName)
                ? null
                : inventory?.GuitarPickups?.FirstOrDefault(p => p.Name == pickupName);
        }
    }
}
