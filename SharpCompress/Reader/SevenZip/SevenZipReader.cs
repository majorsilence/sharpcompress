using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SharpCompress.Common.SevenZip;
using System.IO;
using SharpCompress.Common;

namespace SharpCompress.Reader.SevenZip
{
    public class SevenZipReader : AbstractReader<SevenZipEntry, SevenZipVolume>
    {
        private readonly SevenZipVolume volume;

        internal SevenZipReader(Stream stream, Options options)
            : base(options, ArchiveType.SevenZip)
        {
            volume = new SevenZipVolume(stream, options);
        }

        public override SevenZipVolume Volume
        {
            get { return volume; }
        }

        #region Open

        /// <summary>
        /// Opens a SevenZipReader for Non-seeking usage with a single volume
        /// </summary>
        /// <param name="stream"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        public static SevenZipReader Open(Stream stream,
                                      Options options = Options.KeepStreamsOpen)
        {
            stream.CheckNotNull("stream");
            return new SevenZipReader(stream, options);
        }

        #endregion

        internal override IEnumerable<SevenZipEntry> GetEntries(Stream stream)
        {
            throw new NotImplementedException();
            //return SevenZipEntry.GetEntries(stream);
        }
    }
}
