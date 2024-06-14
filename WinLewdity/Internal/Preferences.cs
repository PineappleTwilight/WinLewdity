using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProtoBuf;

namespace WinLewdity.Internal
{
    [ProtoContract]
    public enum ImagePack
    {
        [Description("Vanilla")]
        [ProtoEnum]
        Vanilla,

        [Description("BEEESSS")]
        [ProtoEnum]
        Bees,

        [Description("BEEESSS Wax")]
        [ProtoEnum]
        BeesWax,

        [Description("BEEESSS + Paril + Hairstyle Extended")]
        [ProtoEnum]
        BeesParilHairExtended,

        [Description("BEEESSS + Okbd")]
        [ProtoEnum]
        BeesOkbd,

        [Description("BEEESSS + Hikari Female")]
        [ProtoEnum]
        BeesHikari_Female,

        [Description("BEEESSS + Hikari Male")]
        [ProtoEnum]
        BeesHikari_Male,

        [Description("Lllysmasc")]
        [ProtoEnum]
        Lllysmasc,

        [Description("Susato")]
        [ProtoEnum]
        Susato,

        [Description("Mizz")]
        [ProtoEnum]
        Mizz,

        [Description("Mellow's Combat Rework")]
        [ProtoEnum]
        MVCR
    }

    [ProtoContract]
    public class Preferences
    {
        [ProtoMember(1)]
        public ImagePack preferredImagePack { get; set; }

        [ProtoMember(2)]
        public bool enableMusic { get; set; }

        [ProtoMember(3)]
        public bool enableSfx { get; set; }

        [ProtoMember(4)]
        public bool enableSexToys { get; set; }

        [ProtoMember(5)]
        public float globalVolume { get; set; }
    }
}