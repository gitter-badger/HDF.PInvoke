﻿/* * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *
 * Copyright by The HDF Group.                                               *
 * Copyright by the Board of Trustees of the University of Illinois.         *
 * All rights reserved.                                                      *
 *                                                                           *
 * This file is part of HDF5.  The full HDF5 copyright notice, including     *
 * terms governing use, modification, and redistribution, is contained in    *
 * the files COPYING and Copyright.html.  COPYING can be found at the root   *
 * of the source code distribution tree; Copyright.html can be found at the  *
 * root level of an installed copy of the electronic HDF5 document set and   *
 * is linked from the top-level documents page.  It can also be found at     *
 * http://hdfgroup.org/HDF5/doc/Copyright.html.  If you do not have          *
 * access to either file, you may request a copy from help@hdfgroup.org.     *
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */

using System;
using System.Runtime.InteropServices;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using HDF.PInvoke;

using hid_t = System.Int32;

namespace UnitTests
{
    public partial class H5FTest
    {
        [TestMethod]
        public void H5Fget_nameTest1()
        {
            IntPtr buf = H5.allocate_memory(new IntPtr(256), 0);

            Assert.IsTrue(
                H5F.get_name(m_v0_test_file, buf,
                new IntPtr(255)).ToInt64() >= 0);

            string name = Marshal.PtrToStringAnsi(buf);
            // names should match
            Assert.AreEqual(m_v0_test_file_name, name);

            Assert.IsTrue(
                H5F.get_name(m_v2_test_file, buf,
                new IntPtr(255)).ToInt64() >= 0);

            name = Marshal.PtrToStringAnsi(buf);
            // names should match
            Assert.AreEqual(m_v2_test_file_name, name);

            Assert.IsTrue(H5.free_memory(buf) >= 0);
        }

        [TestMethod]
        public void H5Fget_nameTest2()
        {
            IntPtr buf = H5.allocate_memory(new IntPtr(256), 0);

            Assert.IsTrue(
                H5F.get_name(Utilities.RandomInvalidHandle(), buf,
                new IntPtr(255)).ToInt64() < 0);

            Assert.IsTrue(H5.free_memory(buf) >= 0);
        }
    }
}