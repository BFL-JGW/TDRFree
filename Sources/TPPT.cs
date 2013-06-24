using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using System.Drawing;
using Microsoft.Office.Core;
using PowerPoint = Microsoft.Office.Interop.PowerPoint;

namespace TDRFree
{
  class TPPT
  {
    private PowerPoint.Application MyApp;
    private PowerPoint.Presentations MyPresentations;
    private PowerPoint.Presentation MyPresentation;
    private PowerPoint.Slides MySlides;
    private PowerPoint.Slide MySlide;
    
    //
    //**********************************************************************************************
    //
    // Class TPPT
    //   Part of  : TDRFree
    //   Function : Interacts with Microsoft Powerpoint to make a presentation
    //   Author   : Jan G. Wesseling
    //   Date     : April 9th, 2013
    //
    //**********************************************************************************************
    //

    public TPPT()
    {
      MyApp = new PowerPoint.Application();
      MyApp.Visible = MsoTriState.msoTrue;
      MyApp.WindowState = PowerPoint.PpWindowState.ppWindowMinimized;
	    MyPresentations = MyApp.Presentations;
      MyPresentation = MyPresentations.Add(MsoTriState.msoFalse);
      MySlides = MyPresentation.Slides;
    }

    //
    //**********************************************************************************************
    //

    public void AddPictureToSlide(String aFile)
    {
      MySlide = MySlides.Add(MySlides.Count+1, PowerPoint.PpSlideLayout.ppLayoutBlank);
      MySlide.Shapes.AddPicture(aFile, MsoTriState.msoFalse, MsoTriState.msoTrue, 0, 0, 800, 600);
    }

    //
    //**********************************************************************************************
    //

    public void SavePresentation(String aFile)
    {
      MyPresentation.SaveAs(aFile, PowerPoint.PpSaveAsFileType.ppSaveAsPresentation, MsoTriState.msoTrue);
      MyPresentation.Close();
      MyApp.Quit();
    }
  }
}
