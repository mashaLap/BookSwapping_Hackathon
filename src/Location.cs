namespace BookSwapping
{

    public class Location
    {
        public enum LocationType
        {
            Neighborhood,
            Work,
            School
        }


        public static int ids;
        public int LocationId { get; set; }
        public string LoctionTitle { get; set; } // microsoft haifa
        public LocationType LocationType1 { get; set; }
        public string LocationDescription { get; set; }



        public Location(string locationTitle, LocationType locationType, string locationDescription)
        {
            ids++;
            LocationId = ids;
            LoctionTitle = locationTitle;
            LocationType1 = locationType;
            LocationDescription = locationDescription;
        }
    }
}

