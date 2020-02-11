# LEADTOOLS Barcode Demo for .NET Framework

This demo falls under the [license located here.](./LICENSE.md)

Powered by patented artificial intelligence and machine learning algorithms, [LEADTOOLS is a collection of award-winning document, medical, multimedia, and imaging SDKs](https://www.leadtools.com)

This .NET WinForms Demo showcases how to read and write barcodes using [LEADTOOLS Barcode SDK](barcode-page).

Read and write barcodes such as:

- 2D Barcodes
  - QR Code
  - Micro QR Code
  - Data Matrix
  - Aztec Code
  - PDF417
  - MicroPDF417
  - MaxiCode
- 1D Barcodes
  - UPC/EAN
  - Code 128
  - 2 of 5
  - GS1 DataBar
  - USPS & 4-State
  - POSTNET
  - PLANET
  - USPS 4-State OneCode (USPS4CB)
  - Royal Mail (RM4SCC)
  - Australian Post - 4 State
  - MSI (Modified Plessey)
  - Code 3 of 9
  - Code 93
  - Code 32
  - Codabar
  - Ames Code
  - USD-4
  - Code 2 of 7
  - Code 11 (USD-8)
  - Patch Code

## Set Up

In order to use any LEADTOOLS functionality, you must have a valid license. You can obtain a fully functional 30-day license [from our website](https://www.leadtools.com/downloads).

Locate the `RasterSupport.SetLicense(licenseFilePath, developerKey);` line in the application and modify the code to point to use your new license and key.

Open the csproj file in Visual Studio. Build the project in order to restore the [LEADTOOLS NuGet packages](https://www.leadtools.com/downloads/nuget).

## Use

With this barcode demo, you can load any image and attempt to read barcodes. Open an image and then press F5 to read all barcodes. To clean up images, review the image processing commands in the Preprocessing menu. Open the Barcode menu to change the various Barcode Read options.

## Resources

Website: <https://www.leadtools.com/>

Download Full Evaluation: <https://www.leadtools.com/downloads>

Documentation: <https://www.leadtools.com/help/leadtools/v20/dh/to/introduction.html>

Technical Support: <https://www.leadtools.com/support/chat>

[barcode-page]: https://www.leadtools.com/sdk/barcode
[nuget-profile]: https://www.nuget.org/profiles/LEADTOOLS
