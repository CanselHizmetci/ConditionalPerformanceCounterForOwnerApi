using System;
namespace Owner.API.DataOperations
{
    public static class DataGenerator
    {
        public static IList<Models.Owner> OwnerList = new List<Models.Owner>()
       {
           new Models.Owner
           {
               Id = 1,
               Name="Owner1",
               Surname="Surname1",
               Type="Type1",
               Date=new DateTime(2018,12,10),
               Content="Lorem ipsum dolor sit amet, consectetur adipiscing elit. Donec ac leo nibh. Ut varius risus ex, a dignissim lectus euismod quis. Phasellus non felis sed sapien mollis suscipit ut nec odio. Cras luctus molestie maximus. Sed bibendum augue purus, vel pharetra enim tristique vel. Aliquam erat volutpat. Aliquam nibh felis, cursus in mauris ut, venenatis egestas magna."

           },
           new Models.Owner
           {
               Id = 2,
               Name="Owner2",
               Surname="Surname2",
               Type="Type2",
               Date=new DateTime(2019,11,12),
               Content="Ut tempor vitae ante sed elementum. Sed eget scelerisque leo. Fusce tempus nulla quis dolor convallis, vitae sodales elit aliquam. Aliquam elementum feugiat rhoncus. Suspendisse condimentum sit amet tortor sit amet ornare. Nulla maximus, elit in feugiat auctor, nisl metus lobortis ligula, ut cursus nisi felis non ex."

           },
            new Models.Owner
           {
               Id = 3,
               Name="Owner3",
               Surname="Surname3",
               Type="Type3",
               Date=new DateTime(2010,8,4),
               Content="Vestibulum pellentesque tortor in quam vestibulum, et vehicula odio laoreet. Suspendisse placerat sed urna et gravida. Ut tincidunt ultricies dapibus. Curabitur feugiat dolor in risus accumsan, quis convallis nisl fringilla. Vestibulum sagittis pulvinar mollis. Etiam ultrices accumsan eros vitae mattis. Curabitur viverra porta suscipit."

           }

       };
    }
}

