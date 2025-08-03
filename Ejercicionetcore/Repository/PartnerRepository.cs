using Ejercicionetcore.Models.Partner;


namespace Ejercicionetcore.Repository
{
    public class PartnerRepository
    {
        static List<PartnerModel> partners = new List<PartnerModel>();

        public List<PartnerModel> GetAllPartners()
        {
            return partners;
        }

        public PartnerModel? GetPartnerById(int id)
        {
            return partners.FirstOrDefault(p => p.IdPartner == id);
        }

        public PartnerModel AddPartner(PartnerAddRequest partner)
        {
            int idPartner = partners.Count > 0 ? partners.Max(p => p.IdPartner) + 1 : 1;
            PartnerModel newPartner = new PartnerModel(idPartner, partner.NamePartner);
            partners.Add(newPartner);
            return newPartner;
        }
        public bool RemovePartner(int id)
        {
            var partner = partners.FirstOrDefault(p => p.IdPartner == id);
            if (partner == null) return false;
            return partners.Remove(partner);
        }



    }
}
