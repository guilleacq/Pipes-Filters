using CompAndDel;

public class SaveFilter : IFilter
{
    private string pictureName;
    public SaveFilter(string name)
    {
        this.pictureName = name;
    }
    public IPicture Filter(IPicture image)
    {
        PictureProvider provider = new PictureProvider();
        provider.SavePicture(image, $"{pictureName}.jpg");

        return image;
    }
}