using System.Collections.Generic;
using Ejercicionetcore.Models.Partner;
using Ejercicionetcore.Repository;
using Ejercicionetcore.Helpers;

namespace Ejercicionetcore.Bll
{
    public class PartnerBll
    {
        private PartnerRepository partnerRepo = new PartnerRepository();

        public List<PartnerModel> GetAllPartners()
        {
            return partnerRepo.GetAllPartners();
        }

        public PartnerModel? GetPartnerById(int id)
        {
            return partnerRepo.GetPartnerById(id);
        }

        public ResponseGeneralModel<PartnerModel> AddPartner(PartnerAddRequest partner)
        {
            if (string.IsNullOrWhiteSpace(partner.NamePartner))
            {
                return new ResponseGeneralModel<PartnerModel>(400, null, "El nombre del colaborador es obligatorio.");
            }

            var test = partnerRepo.AddPartner(partner);

            PartnerModel partnerAdd = new PartnerModel(test.IdPartner, test.NamePartner);
            return new ResponseGeneralModel<PartnerModel>(200, partnerAdd, "Colaborador agregado correctamente.");
        }

        public ResponseGeneralModel<string> DeletePartner(int id)
        {
            bool removed = partnerRepo.RemovePartner(id);
            if (removed)
                return new ResponseGeneralModel<string>(200, null, "Colaborador eliminado correctamente");
            else
                return new ResponseGeneralModel<string>(404, null, "Colaborador no encontrado");
        }



    }
}
