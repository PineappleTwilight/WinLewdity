using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProtoBuf;

namespace SimpleHtmlViewer.Internal
{
    [ProtoContract]
    public enum ImagePack
    {
        [ProtoEnum]
        Vanilla,

        [ProtoEnum]
        Bees,

        [ProtoEnum]
        BeesWax,

        [ProtoEnum]
        BeesParilHairExtended,

        [ProtoEnum]
        BeesOkbd,

        [ProtoEnum]
        BeesHikari_Female,

        [ProtoEnum]
        BeesHikari_Male,

        [ProtoEnum]
        Lllysmasc,

        [ProtoEnum]
        Susato,

        [ProtoEnum]
        Mizz,

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