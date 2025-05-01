using Microsoft.Data.SqlClient;
using System.Data;

public class GenIndividualsLoader
{
    private readonly string _connString;

    public GenIndividualsLoader(string connectionString)
    {
        _connString = connectionString;
    }

    /// <summary>
    /// Inserts one record into GenIndividuals with every column parameter explicit.
    /// </summary>
    public async Task InsertAsync(
        string? ID_INDIVIDU = null,
        string? ID_FATHER = null,
        string? ID_MOTHER = null,
        string Sex = null,
        string PATRONYME = null,
        string Given_name = null,
        string Nickname = null,
        string Text_after_the_name = null,
        string Birth_Date = null,
        string Birth_Place = null,
        string Birth_Link = null,
        string Birth_Link_1 = null,
        string Religion_Date = null,
        string Religion_Place = null,
        string Baptism_Date = null,
        string Baptism_Place = null,
        string Christening_Date = null,
        string Christening_Place = null,
        string Christening_Link = null,
        string Education_attained = null,
        string Education_attained_Date = null,
        string Education_attained_Place = null,
        string Graduation_Date = null,
        string Graduation_Place = null,
        string Occupation = null,
        string Occupation_Date = null,
        string Occupation_Place = null,
        string Partner = null,
        string Generation = null,
        string Religion = null,
        string Family_Status = null,
        string Family_Status_Date = null,
        string Family_Status_Place = null,
        string Dietary = null,
        string Dietary_Date = null,
        string Dietary_Place = null,
        string Military_Service = null,
        string Military_Service_Date = null,
        string Military_Service_Place = null,
        string Naturalization = null,
        string Naturalization_Date = null,
        string Naturalization_Place = null,
        string Death_Date = null,
        string Death_Place = null,
        string Burial_Date = null,
        string Burial_Place = null,
        string Obituary = null,
        string Obituary_Date = null,
        string Obituary_Place = null,
        string Grave_Inscription = null,
        string Grave_Inscription_Date = null,
        string Grave_Inscription_Place = null,
        string FGRAVE = null,
        string FGRAVE_Date = null,
        string FGRAVE_Date_1 = null,
        string FGLINK = null,
        string FGLINK_Date = null,
        string FGLINK_Date_1 = null,
        string FSFTID = null,
        string FSFTID_Date = null,
        string FSFTID_Date_1 = null,
        string FSLINK = null,
        string FSLINK_Date = null,
        string FSLINK_Date_1 = null,
        string Source = null,
        string UID = null,
        string CSTAT = null,
        string CSTAT_Date = null,
        string CSTAT_Date_1 = null,
        string TAG8 = null,
        string TAG8_Date = null,
        string TAG8_Date_1 = null,
        string PPEXCLUDE = null,
        string PPEXCLUDE_Date = null,
        string PPEXCLUDE_Date_1 = null,
        string Unnamed_52 = null
    )
    {
        using var conn = new SqlConnection(_connString);
        using var cmd = new SqlCommand("dbo.usp_InsertGenIndividuals", conn)
        {
            CommandType = CommandType.StoredProcedure
        };

        cmd.Parameters.AddWithValue("@ID_INDIVIDU", (object)ID_INDIVIDU ?? DBNull.Value);
        cmd.Parameters.AddWithValue("@ID_FATHER", (object)ID_FATHER ?? DBNull.Value);
        cmd.Parameters.AddWithValue("@ID_MOTHER", (object)ID_MOTHER ?? DBNull.Value);
        cmd.Parameters.AddWithValue("@Sex", (object)Sex ?? DBNull.Value);
        cmd.Parameters.AddWithValue("@PATRONYME", (object)PATRONYME ?? DBNull.Value);
        cmd.Parameters.AddWithValue("@Given_name", (object)Given_name ?? DBNull.Value);
        cmd.Parameters.AddWithValue("@Nickname", (object)Nickname ?? DBNull.Value);
        cmd.Parameters.AddWithValue("@Text_after_the_name", (object)Text_after_the_name ?? DBNull.Value);
        cmd.Parameters.AddWithValue("@Birth_Date", (object)Birth_Date ?? DBNull.Value);
        cmd.Parameters.AddWithValue("@Birth_Place", (object)Birth_Place ?? DBNull.Value);
        cmd.Parameters.AddWithValue("@Birth_Link", (object)Birth_Link ?? DBNull.Value);
        cmd.Parameters.AddWithValue("@Birth_Link_1", (object)Birth_Link_1 ?? DBNull.Value);
        cmd.Parameters.AddWithValue("@Religion_Date", (object)Religion_Date ?? DBNull.Value);
        cmd.Parameters.AddWithValue("@Religion_Place", (object)Religion_Place ?? DBNull.Value);
        cmd.Parameters.AddWithValue("@Baptism_Date", (object)Baptism_Date ?? DBNull.Value);
        cmd.Parameters.AddWithValue("@Baptism_Place", (object)Baptism_Place ?? DBNull.Value);
        cmd.Parameters.AddWithValue("@Christening_Date", (object)Christening_Date ?? DBNull.Value);
        cmd.Parameters.AddWithValue("@Christening_Place", (object)Christening_Place ?? DBNull.Value);
        cmd.Parameters.AddWithValue("@Christening_Link", (object)Christening_Link ?? DBNull.Value);
        cmd.Parameters.AddWithValue("@Education_attained", (object)Education_attained ?? DBNull.Value);
        cmd.Parameters.AddWithValue("@Education_attained_Date", (object)Education_attained_Date ?? DBNull.Value);
        cmd.Parameters.AddWithValue("@Education_attained_Place", (object)Education_attained_Place ?? DBNull.Value);
        cmd.Parameters.AddWithValue("@Graduation_Date", (object)Graduation_Date ?? DBNull.Value);
        cmd.Parameters.AddWithValue("@Graduation_Place", (object)Graduation_Place ?? DBNull.Value);
        cmd.Parameters.AddWithValue("@Occupation", (object)Occupation ?? DBNull.Value);
        cmd.Parameters.AddWithValue("@Occupation_Date", (object)Occupation_Date ?? DBNull.Value);
        cmd.Parameters.AddWithValue("@Occupation_Place", (object)Occupation_Place ?? DBNull.Value);
        cmd.Parameters.AddWithValue("@Partner", (object)Partner ?? DBNull.Value);
        cmd.Parameters.AddWithValue("@Generation", (object)Generation ?? DBNull.Value);
        cmd.Parameters.AddWithValue("@Religion", (object)Religion ?? DBNull.Value);
        cmd.Parameters.AddWithValue("@Family_Status", (object)Family_Status ?? DBNull.Value);
        cmd.Parameters.AddWithValue("@Family_Status_Date", (object)Family_Status_Date ?? DBNull.Value);
        cmd.Parameters.AddWithValue("@Family_Status_Place", (object)Family_Status_Place ?? DBNull.Value);
        cmd.Parameters.AddWithValue("@Dietary", (object)Dietary ?? DBNull.Value);
        cmd.Parameters.AddWithValue("@Dietary_Date", (object)Dietary_Date ?? DBNull.Value);
        cmd.Parameters.AddWithValue("@Dietary_Place", (object)Dietary_Place ?? DBNull.Value);
        cmd.Parameters.AddWithValue("@Military_Service", (object)Military_Service ?? DBNull.Value);
        cmd.Parameters.AddWithValue("@Military_Service_Date", (object)Military_Service_Date ?? DBNull.Value);
        cmd.Parameters.AddWithValue("@Military_Service_Place", (object)Military_Service_Place ?? DBNull.Value);
        cmd.Parameters.AddWithValue("@Naturalization", (object)Naturalization ?? DBNull.Value);
        cmd.Parameters.AddWithValue("@Naturalization_Date", (object)Naturalization_Date ?? DBNull.Value);
        cmd.Parameters.AddWithValue("@Naturalization_Place", (object)Naturalization_Place ?? DBNull.Value);
        cmd.Parameters.AddWithValue("@Death_Date", (object)Death_Date ?? DBNull.Value);
        cmd.Parameters.AddWithValue("@Death_Place", (object)Death_Place ?? DBNull.Value);
        cmd.Parameters.AddWithValue("@Burial_Date", (object)Burial_Date ?? DBNull.Value);
        cmd.Parameters.AddWithValue("@Burial_Place", (object)Burial_Place ?? DBNull.Value);
        cmd.Parameters.AddWithValue("@Obituary", (object)Obituary ?? DBNull.Value);
        cmd.Parameters.AddWithValue("@Obituary_Date", (object)Obituary_Date ?? DBNull.Value);
        cmd.Parameters.AddWithValue("@Obituary_Place", (object)Obituary_Place ?? DBNull.Value);
        cmd.Parameters.AddWithValue("@Grave_Inscription", (object)Grave_Inscription ?? DBNull.Value);
        cmd.Parameters.AddWithValue("@Grave_Inscription_Date", (object)Grave_Inscription_Date ?? DBNull.Value);
        cmd.Parameters.AddWithValue("@Grave_Inscription_Place", (object)Grave_Inscription_Place ?? DBNull.Value);
        cmd.Parameters.AddWithValue("@FGRAVE", (object)FGRAVE ?? DBNull.Value);
        cmd.Parameters.AddWithValue("@FGRAVE_Date", (object)FGRAVE_Date ?? DBNull.Value);
        cmd.Parameters.AddWithValue("@FGRAVE_Date_1", (object)FGRAVE_Date_1 ?? DBNull.Value);
        cmd.Parameters.AddWithValue("@FGLINK", (object)FGLINK ?? DBNull.Value);
        cmd.Parameters.AddWithValue("@FGLINK_Date", (object)FGLINK_Date ?? DBNull.Value);
        cmd.Parameters.AddWithValue("@FGLINK_Date_1", (object)FGLINK_Date_1 ?? DBNull.Value);
        cmd.Parameters.AddWithValue("@FSFTID", (object)FSFTID ?? DBNull.Value);
        cmd.Parameters.AddWithValue("@FSFTID_Date", (object)FSFTID_Date ?? DBNull.Value);
        cmd.Parameters.AddWithValue("@FSFTID_Date_1", (object)FSFTID_Date_1 ?? DBNull.Value);
        cmd.Parameters.AddWithValue("@FSLINK", (object)FSLINK ?? DBNull.Value);
        cmd.Parameters.AddWithValue("@FSLINK_Date", (object)FSLINK_Date ?? DBNull.Value);
        cmd.Parameters.AddWithValue("@FSLINK_Date_1", (object)FSLINK_Date_1 ?? DBNull.Value);
        cmd.Parameters.AddWithValue("@Source", (object)Source ?? DBNull.Value);
        cmd.Parameters.AddWithValue("@UID", (object)UID ?? DBNull.Value);
        cmd.Parameters.AddWithValue("@CSTAT", (object)CSTAT ?? DBNull.Value);
        cmd.Parameters.AddWithValue("@CSTAT_Date", (object)CSTAT_Date ?? DBNull.Value);
        cmd.Parameters.AddWithValue("@CSTAT_Date_1", (object)CSTAT_Date_1 ?? DBNull.Value);
        cmd.Parameters.AddWithValue("@TAG8", (object)TAG8 ?? DBNull.Value);
        cmd.Parameters.AddWithValue("@TAG8_Date", (object)TAG8_Date ?? DBNull.Value);
        cmd.Parameters.AddWithValue("@TAG8_Date_1", (object)TAG8_Date_1 ?? DBNull.Value);
        cmd.Parameters.AddWithValue("@PPEXCLUDE", (object)PPEXCLUDE ?? DBNull.Value);
        cmd.Parameters.AddWithValue("@PPEXCLUDE_Date", (object)PPEXCLUDE_Date ?? DBNull.Value);
        cmd.Parameters.AddWithValue("@PPEXCLUDE_Date_1", (object)PPEXCLUDE_Date_1 ?? DBNull.Value);
        cmd.Parameters.AddWithValue("@Unnamed_52", (object)Unnamed_52 ?? DBNull.Value);

        await conn.OpenAsync();
        await cmd.ExecuteNonQueryAsync();
    }
}
