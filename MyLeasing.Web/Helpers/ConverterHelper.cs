using MyLeasing.Web.Data.Entities;
using MyLeasing.Web.Models;
using System.IO;

namespace MyLeasing.Web.Helpers
{
    public class ConverterHelper : IConverterHelper
    {
        public Owner ToOwner(OwnerViewModel model, string path, bool isNew)
        {
            return new Owner
            {
                Id = isNew ? 0 : model.Id,
                Document = model.Document,
                FirstName = model.FirstName,
                LastName = model.LastName,
                Address = model.Address,
                CellPhone = model.CellPhone,
                FixedPhone = model.FixedPhone,
                PhotoUrl = path,
                User = model.User
            };
        }

        public OwnerViewModel ToOwnerViewModel(Owner owner)
        {
            return new OwnerViewModel
            {
                Id = owner.Id,
                Document = owner.Document,
                FirstName = owner.FirstName,
                LastName = owner.LastName,
                Address = owner.Address,
                CellPhone = owner.CellPhone,
                FixedPhone = owner.FixedPhone,
                PhotoUrl = owner.PhotoUrl,
                User = owner.User
            };
        }

        public Lessee ToLessee(LesseeViewModel model, string path, bool isNew)
        {
            return new Lessee
            {
                Id = isNew ? 0 : model.Id,
                Document = model.Document,
                FirstName = model.FirstName,
                LastName = model.LastName,
                Address = model.Address,
                CellPhone = model.CellPhone,
                FixedPhone = model.FixedPhone,
                PhotoUrl = path,
                User = model.User
            };
        }

        public LesseeViewModel ToLesseeViewModel(Lessee lessee)
        {
            return new LesseeViewModel
            {
                Id = lessee.Id,
                Document = lessee.Document,
                FirstName = lessee.FirstName,
                LastName = lessee.LastName,
                Address = lessee.Address,
                CellPhone = lessee.CellPhone,
                FixedPhone = lessee.FixedPhone,
                PhotoUrl = lessee.PhotoUrl,
                User = lessee.User
            };
        }
    }
}
