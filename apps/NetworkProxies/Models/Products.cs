using System.Text.Json.Serialization;

namespace NetworkProxies.Models
{
    // 1. Optional: Use this ONLY if you are passing the exact raw text string 
    // containing the "status" and "body" fields.
    public record OpenBankingApiWrapper(
        [property: JsonPropertyName("status")] string Status,
        [property: JsonPropertyName("body")] string Body
    );

    // 2. The Standard Open Banking Root Structure
    public record OpenBankingPcaRoot(
        [property: JsonPropertyName("meta")] Meta Meta,
        [property: JsonPropertyName("data")] List<BrandContainer> Data
    );

    public record Meta(
        [property: JsonPropertyName("LastUpdated")] DateTime LastUpdated,
        [property: JsonPropertyName("TotalResults")] int TotalResults,
        [property: JsonPropertyName("Agreement")] string Agreement,
        [property: JsonPropertyName("License")] string License,
        [property: JsonPropertyName("TermsOfUse")] string TermsOfUse
    );

    public record BrandContainer(
        [property: JsonPropertyName("Brand")] List<BrandData> Brand
    );

    public record BrandData(
        [property: JsonPropertyName("BrandName")] string BrandName,
        [property: JsonPropertyName("PCA")] List<PcaProduct> Pca
    );

    public record PcaProduct(
        [property: JsonPropertyName("Name")] string Name,
        [property: JsonPropertyName("Identification")] string Identification,
        [property: JsonPropertyName("OnSaleIndicator")] bool OnSaleIndicator,
        [property: JsonPropertyName("PCAMarketingState")] List<MarketingState> PcaMarketingState
    );

    public record MarketingState(
        [property: JsonPropertyName("Identification")] string Identification,
        [property: JsonPropertyName("CoreProduct")] CoreProduct CoreProduct,
        [property: JsonPropertyName("FeaturesAndBenefits")] FeaturesAndBenefits FeaturesAndBenefits,
        [property: JsonPropertyName("MarketingState")] string StateType,
        [property: JsonPropertyName("FirstMarketedDate")] string FirstMarketedDate,
        [property: JsonPropertyName("LastMarketedDate")] string LastMarketedDate,
        [property: JsonPropertyName("OtherFeesCharges")] OtherFeesCharges OtherFeesCharges
    );

    public record CoreProduct(
        [property: JsonPropertyName("ProductDescription")] string ProductDescription,
        [property: JsonPropertyName("ProductURL")] string ProductUrl,
        [property: JsonPropertyName("TcsAndCsURL")] string TcsAndCsUrl,
        [property: JsonPropertyName("MonthlyMaximumCharge")] string MonthlyMaximumCharge,
        [property: JsonPropertyName("SalesAccessChannels")] List<string> SalesAccessChannels,
        [property: JsonPropertyName("ServicingAccessChannels")] List<string> ServicingAccessChannels
    );

    public record FeaturesAndBenefits(
        [property: JsonPropertyName("FeatureBenefitItem")] List<FeatureBenefitItem> FeatureBenefitItem
    );

    public record FeatureBenefitItem(
        [property: JsonPropertyName("Identification")] string Identification,
        [property: JsonPropertyName("Name")] string Name,
        [property: JsonPropertyName("Type")] string Type,
        [property: JsonPropertyName("Indicator")] bool? Indicator, // Nullable because it is missing when 'Textual' is used
        [property: JsonPropertyName("Textual")] string? Textual
    );

    public record OtherFeesCharges(
        [property: JsonPropertyName("FeeChargeDetail")] List<FeeChargeDetail> FeeChargeDetail
    );

    public record FeeChargeDetail(
        [property: JsonPropertyName("FeeCategory")] string FeeCategory,
        [property: JsonPropertyName("FeeType")] string FeeType,
        [property: JsonPropertyName("Notes")] List<string> Notes,
        [property: JsonPropertyName("FeeRate")] string? FeeRate,   // String format from API to safely preserve decimal points
        [property: JsonPropertyName("FeeAmount")] string? FeeAmount,
        [property: JsonPropertyName("ApplicationFrequency")] string ApplicationFrequency,
        [property: JsonPropertyName("CalculationFrequency")] string CalculationFrequency
    );
}
