using Microsoft.VisualStudio.TestTools.UnitTesting;
using SharpCompress.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SharpCompress.Test
{
    [TestClass]
    public class SevenZipWriterTests : WriterTests
    {

        public SevenZipWriterTests()
            : base(ArchiveType.SevenZip)
        {
            UseExtensionInsteadOfNameToVerify = true;
        }

        [TestMethod]
        public void SevenZipArchive_LZMA_StreamWrite()
        {
            Write(CompressionType.LZMA, "7Zip.LZMA.7z", "7Zip.LZMA.7z");
        }

    }
}
