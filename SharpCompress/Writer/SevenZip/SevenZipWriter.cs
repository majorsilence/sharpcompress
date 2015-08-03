using SharpCompress.Common;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using SharpCompress.Compressor;
using SharpCompress.Compressor.LZMA;

namespace SharpCompress.Writer.SevenZip
{
    public class SevenZipWriter: AbstractWriter
    {
   
        public SevenZipWriter(Stream destination)
            : base(ArchiveType.SevenZip)
        {
            var prop = new LzmaEncoderProperties();
            InitalizeStream(new LzmaStream(prop, false, destination), true);
        }

        protected override void Dispose(bool isDisposing)
        {
            if (isDisposing)
            {
                OutputStream.Dispose();
            }
            base.Dispose(isDisposing);
        }

        public override void Write(string filename, Stream source, DateTime? modificationTime)
        {
            var stream = OutputStream as LzmaStream;
            source.TransferTo(stream);
    
        }
    }
}
