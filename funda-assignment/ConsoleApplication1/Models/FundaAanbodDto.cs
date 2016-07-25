using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace ConsoleApplication1.Models
{
    [DataContract]
    public class FundaAanbodMetadataDto
    {
        [DataMember(Name = "ObjectType")]
        public string ObjectType { get; set; }

        [DataMember(Name = "Omschrijving")]
        public string Omschrijving { get; set; }

        [DataMember(Name = "Titel")]
        public string Titel { get; set; }
    }

    [DataContract]
    public class FundaAanbodPrijsDto
    {
        [DataMember(Name = "GeenExtraKosten")]
        public bool GeenExtraKosten { get; set; }

        [DataMember(Name = "HuurAbbreviation")]
        public string HuurAbbreviation { get; set; }

        [DataMember(Name = "Huurprijs")]
        public object Huurprijs { get; set; }

        [DataMember(Name = "HuurprijsOpAanvraag")]
        public string HuurprijsOpAanvraag { get; set; }

        [DataMember(Name = "HuurprijsTot")]
        public object HuurprijsTot { get; set; }

        [DataMember(Name = "KoopAbbreviation")]
        public string KoopAbbreviation { get; set; }

        [DataMember(Name = "Koopprijs")]
        public int? Koopprijs { get; set; }

        [DataMember(Name = "KoopprijsOpAanvraag")]
        public string KoopprijsOpAanvraag { get; set; }

        [DataMember(Name = "KoopprijsTot")]
        public int? KoopprijsTot { get; set; }

        [DataMember(Name = "OriginelePrijs")]
        public object OriginelePrijs { get; set; }

        [DataMember(Name = "VeilingText")]
        public string VeilingText { get; set; }
    }

    [DataContract]
    public class FundaAanbodProjectDto
    {
        [DataMember(Name = "AantalKamersTotEnMet")]
        public object AantalKamersTotEnMet { get; set; }

        [DataMember(Name = "AantalKamersVan")]
        public object AantalKamersVan { get; set; }

        [DataMember(Name = "AantalKavels")]
        public object AantalKavels { get; set; }

        [DataMember(Name = "Adres")]
        public object Adres { get; set; }

        [DataMember(Name = "FriendlyUrl")]
        public object FriendlyUrl { get; set; }

        [DataMember(Name = "GewijzigdDatum")]
        public object GewijzigdDatum { get; set; }

        [DataMember(Name = "GlobalId")]
        public object GlobalId { get; set; }

        [DataMember(Name = "HoofdFoto")]
        public string HoofdFoto { get; set; }

        [DataMember(Name = "IndIpix")]
        public bool IndIpix { get; set; }

        [DataMember(Name = "IndPDF")]
        public bool IndPDF { get; set; }

        [DataMember(Name = "IndPlattegrond")]
        public bool IndPlattegrond { get; set; }

        [DataMember(Name = "IndTop")]
        public bool IndTop { get; set; }

        [DataMember(Name = "IndVideo")]
        public bool IndVideo { get; set; }

        [DataMember(Name = "InternalId")]
        public string InternalId { get; set; }

        [DataMember(Name = "MaxWoonoppervlakte")]
        public object MaxWoonoppervlakte { get; set; }

        [DataMember(Name = "MinWoonoppervlakte")]
        public object MinWoonoppervlakte { get; set; }

        [DataMember(Name = "Naam")]
        public object Naam { get; set; }

        [DataMember(Name = "Omschrijving")]
        public object Omschrijving { get; set; }

        [DataMember(Name = "OpenHuizen")]
        public IList<object> OpenHuizen { get; set; }

        [DataMember(Name = "Plaats")]
        public object Plaats { get; set; }

        [DataMember(Name = "FundaAanbodPrijsDto")]
        public object Prijs { get; set; }

        [DataMember(Name = "PrijsGeformatteerd")]
        public object PrijsGeformatteerd { get; set; }

        [DataMember(Name = "PublicatieDatum")]
        public object PublicatieDatum { get; set; }

        [DataMember(Name = "Type")]
        public int? Type { get; set; }

        [DataMember(Name = "Woningtypen")]
        public object Woningtypen { get; set; }
    }

    [DataContract]
    public class PromoLabel
    {
        [DataMember(Name = "HasPromotionLabel")]
        public bool HasPromotionLabel { get; set; }

        [DataMember(Name = "PromotionPhotos")]
        public IList<object> PromotionPhotos { get; set; }

        [DataMember(Name = "PromotionPhotosSecure")]
        public object PromotionPhotosSecure { get; set; }

        [DataMember(Name = "PromotionType")]
        public int? PromotionType { get; set; }

        [DataMember(Name = "RibbonColor")]
        public int? RibbonColor { get; set; }

        [DataMember(Name = "RibbonText")]
        public object RibbonText { get; set; }

        [DataMember(Name = "Tagline")]
        public object Tagline { get; set; }
    }

    [DataContract(Name = "Object")]
    public class FundaObject
    {
        [DataMember(Name = "AangebodenSindsTekst")]
        public string AangebodenSindsTekst { get; set; }

        [DataMember(Name = "AanmeldDatum")]
        public DateTime AanmeldDatum { get; set; }

        [DataMember(Name = "AantalKamers")]
        public int? AantalKamers { get; set; }

        [DataMember(Name = "AantalKavels")]
        public object AantalKavels { get; set; }

        [DataMember(Name = "Adres")]
        public string Adres { get; set; }

        [DataMember(Name = "Afstand")]
        public int? Afstand { get; set; }

        [DataMember(Name = "BronCode")]
        public string BronCode { get; set; }

        [DataMember(Name = "ChildrenObjects")]
        public IList<object> ChildrenObjects { get; set; }

        [DataMember(Name = "DatumOndertekeningAkte")]
        public object DatumOndertekeningAkte { get; set; }

        [DataMember(Name = "Foto")]
        public string Foto { get; set; }

        [DataMember(Name = "FotoLarge")]
        public string FotoLarge { get; set; }

        [DataMember(Name = "FotoLargest")]
        public string FotoLargest { get; set; }

        [DataMember(Name = "FotoMedium")]
        public string FotoMedium { get; set; }

        [DataMember(Name = "FotoSecure")]
        public string FotoSecure { get; set; }

        [DataMember(Name = "GewijzigdDatum")]
        public object GewijzigdDatum { get; set; }

        [DataMember(Name = "GlobalId")]
        public int? GlobalId { get; set; }

        [DataMember(Name = "GroupByObjectType")]
        public string GroupByObjectType { get; set; }

        [DataMember(Name = "Heeft360GradenFoto")]
        public bool Heeft360GradenFoto { get; set; }

        [DataMember(Name = "HeeftBrochure")]
        public bool HeeftBrochure { get; set; }

        [DataMember(Name = "HeeftOpenhuizenTopper")]
        public bool HeeftOpenhuizenTopper { get; set; }

        [DataMember(Name = "HeeftOverbruggingsgrarantie")]
        public bool HeeftOverbruggingsgrarantie { get; set; }

        [DataMember(Name = "HeeftPlattegrond")]
        public bool HeeftPlattegrond { get; set; }

        [DataMember(Name = "HeeftTophuis")]
        public bool HeeftTophuis { get; set; }

        [DataMember(Name = "HeeftVeiling")]
        public bool HeeftVeiling { get; set; }

        [DataMember(Name = "HeeftVideo")]
        public bool HeeftVideo { get; set; }

        [DataMember(Name = "HuurPrijsTot")]
        public object HuurPrijsTot { get; set; }

        [DataMember(Name = "Huurprijs")]
        public object Huurprijs { get; set; }

        [DataMember(Name = "HuurprijsFormaat")]
        public object HuurprijsFormaat { get; set; }

        [DataMember(Name = "Id")]
        public string Id { get; set; }

        [DataMember(Name = "InUnitsVanaf")]
        public object InUnitsVanaf { get; set; }

        [DataMember(Name = "IndProjectObjectType")]
        public bool IndProjectObjectType { get; set; }

        [DataMember(Name = "IndTransactieMakelaarTonen")]
        public object IndTransactieMakelaarTonen { get; set; }

        [DataMember(Name = "IsSearchable")]
        public bool IsSearchable { get; set; }

        [DataMember(Name = "IsVerhuurd")]
        public bool IsVerhuurd { get; set; }

        [DataMember(Name = "IsVerkocht")]
        public bool IsVerkocht { get; set; }

        [DataMember(Name = "IsVerkochtOfVerhuurd")]
        public bool IsVerkochtOfVerhuurd { get; set; }

        [DataMember(Name = "Koopprijs")]
        public int? Koopprijs { get; set; }

        [DataMember(Name = "KoopprijsFormaat")]
        public string KoopprijsFormaat { get; set; }

        [DataMember(Name = "KoopprijsTot")]
        public int? KoopprijsTot { get; set; }

        [DataMember(Name = "MakelaarId")]
        public int? MakelaarId { get; set; }

        [DataMember(Name = "MakelaarNaam")]
        public string MakelaarNaam { get; set; }

        [DataMember(Name = "MobileURL")]
        public string MobileURL { get; set; }

        [DataMember(Name = "Note")]
        public object Note { get; set; }

        [DataMember(Name = "OpenHuis")]
        public IList<DateTime> OpenHuis { get; set; }

        [DataMember(Name = "Oppervlakte")]
        public int? Oppervlakte { get; set; }

        [DataMember(Name = "Perceeloppervlakte")]
        public int? Perceeloppervlakte { get; set; }

        [DataMember(Name = "Postcode")]
        public string Postcode { get; set; }

        [DataMember(Name = "FundaAanbodPrijsDto")]
        public FundaAanbodPrijsDto FundaAanbodPrijsDto { get; set; }

        [DataMember(Name = "PrijsGeformatteerdHtml")]
        public string PrijsGeformatteerdHtml { get; set; }

        [DataMember(Name = "PrijsGeformatteerdTextHuur")]
        public string PrijsGeformatteerdTextHuur { get; set; }

        [DataMember(Name = "PrijsGeformatteerdTextKoop")]
        public string PrijsGeformatteerdTextKoop { get; set; }

        [DataMember(Name = "Producten")]
        public IList<string> Producten { get; set; }

        [DataMember(Name = "FundaAanbodProjectDto")]
        public FundaAanbodProjectDto FundaAanbodProjectDto { get; set; }

        [DataMember(Name = "ProjectNaam")]
        public object ProjectNaam { get; set; }

        [DataMember(Name = "PromoLabel")]
        public PromoLabel PromoLabel { get; set; }

        [DataMember(Name = "PublicatieDatum")]
        public DateTime PublicatieDatum { get; set; }

        [DataMember(Name = "PublicatieStatus")]
        public int? PublicatieStatus { get; set; }

        [DataMember(Name = "SavedDate")]
        public object SavedDate { get; set; }

        [DataMember(Name = "Soort-aanbod")]
        public string Soort_Aanbod { get; set; }

        [DataMember(Name = "SoortAanbod")]
        public int? SoortAanbod { get; set; }

        [DataMember(Name = "StartOplevering")]
        public object StartOplevering { get; set; }

        [DataMember(Name = "TimeAgoText")]
        public object TimeAgoText { get; set; }

        [DataMember(Name = "TransactieAfmeldDatum")]
        public object TransactieAfmeldDatum { get; set; }

        [DataMember(Name = "TransactieMakelaarId")]
        public object TransactieMakelaarId { get; set; }

        [DataMember(Name = "TransactieMakelaarNaam")]
        public object TransactieMakelaarNaam { get; set; }

        [DataMember(Name = "TypeProject")]
        public int? TypeProject { get; set; }

        [DataMember(Name = "URL")]
        public string URL { get; set; }

        [DataMember(Name = "VerkoopStatus")]
        public string VerkoopStatus { get; set; }

        [DataMember(Name = "WGS84_X")]
        public double WGS84_X { get; set; }

        [DataMember(Name = "WGS84_Y")]
        public double WGS84_Y { get; set; }

        [DataMember(Name = "WoonOppervlakteTot")]
        public int? WoonOppervlakteTot { get; set; }

        [DataMember(Name = "Woonoppervlakte")]
        public int? Woonoppervlakte { get; set; }

        [DataMember(Name = "Woonplaats")]
        public string Woonplaats { get; set; }

        [DataMember(Name = "ZoekType")]
        public IList<int> ZoekType { get; set; }
    }

    [DataContract]
    public class Paging
    {
        [DataMember(Name = "AantalPaginas")]
        public int? AantalPaginas { get; set; }

        [DataMember(Name = "HuidigePagina")]
        public int? HuidigePagina { get; set; }

        [DataMember(Name = "VolgendeUrl")]
        public object VolgendeUrl { get; set; }

        [DataMember(Name = "VorigeUrl")]
        public object VorigeUrl { get; set; }
    }

    [DataContract]
    public class FundaAanbodDto
    {
        [DataMember(Name = "AccountStatus")]
        public int? AccountStatus { get; set; }

        [DataMember(Name = "ValidationFailed")]
        public bool ValidationFailed { get; set; }

        [DataMember(Name = "ValidationReport")]
        public object ValidationReport { get; set; }

        [DataMember(Name = "Website")]
        public int? Website { get; set; }

        [DataMember(Name = "FundaAanbodMetadataDto")]
        public FundaAanbodMetadataDto FundaAanbodMetadataDto { get; set; }

        [DataMember(Name = "Objects")]
        public IList<FundaObject> Objects { get; set; }

        [DataMember(Name = "Paging")]
        public Paging Paging { get; set; }

        [DataMember(Name = "TotaalAantalObjecten")]
        public int? TotaalAantalObjecten { get; set; }
    }
}