using System;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace DirScanNet.SettingsHelper
{
    [XmlRoot("Settings")]
    public sealed class Settings
    {
        static readonly string path = "Settings.xml";
        static readonly XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces(new[] { new XmlQualifiedName("") });
        static readonly XmlSerializer serializer = new XmlSerializer(typeof(Settings));

        static readonly Lazy<Settings> instance = new Lazy<Settings>(LoadSettings);

        public static Settings Instance => instance.Value;

        static Settings LoadSettings()
        {
            if (!File.Exists(path)) return new Settings();
            using (Stream stream = File.OpenRead(path))
                return (Settings)serializer.Deserialize(stream);
        }

        public static void Save() => Instance.SaveSettings();

        Settings() { }

        void SaveSettings()
        {
            using (Stream stream = File.Create(path))
                serializer.Serialize(stream, this, namespaces);
        }

        public MainWindowSettings MainWindowSettings { get; set; } = new MainWindowSettings();
    }
}