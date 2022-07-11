using System.Text.Json.Serialization;

namespace SaveLoadSample
{
    internal class SamplePlayer
    {
        public string? Name { get; set; }
        public int Level { get; set; }
        public IList<SampleItem> Items { get; set; }

        [JsonIgnore] //無視する（今回でいえばSaveする必要がない）メンバに付与
        public string? IgnoredMember { get; set; }

        public SamplePlayer()
        {
            Items = new List<SampleItem>();
        }

        public override string ToString()
        {
            return $"Name：{Name} Level：{Level} Items: {Items.Count} Items[0].Name: {Items.FirstOrDefault()?.Name} IgnoredMember: {IgnoredMember}";
        }
    }
}
