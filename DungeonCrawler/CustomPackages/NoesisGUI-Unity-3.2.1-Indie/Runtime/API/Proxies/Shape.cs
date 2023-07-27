//------------------------------------------------------------------------------
// <auto-generated />
//
// This file was automatically generated by SWIG (http://www.swig.org).
// Version 3.0.10
//
// Do not make changes to this file unless you know what you are doing--modify
// the SWIG interface file instead.
//------------------------------------------------------------------------------


using System;
using System.Runtime.InteropServices;

namespace Noesis
{

public abstract class Shape : FrameworkElement {
  internal Shape(IntPtr cPtr, bool cMemoryOwn) : base(cPtr, cMemoryOwn) {
  }

  internal static HandleRef getCPtr(Shape obj) {
    return (obj == null) ? new HandleRef(null, IntPtr.Zero) : obj.swigCPtr;
  }

  protected Shape() {
  }

  internal protected abstract Geometry DefiningGeometry { get; }

  public static DependencyProperty FillProperty {
    get {
      IntPtr cPtr = NoesisGUI_PINVOKE.Shape_FillProperty_get();
      return (DependencyProperty)Noesis.Extend.GetProxy(cPtr, false);
    }
  }

  public static DependencyProperty StretchProperty {
    get {
      IntPtr cPtr = NoesisGUI_PINVOKE.Shape_StretchProperty_get();
      return (DependencyProperty)Noesis.Extend.GetProxy(cPtr, false);
    }
  }

  public static DependencyProperty StrokeProperty {
    get {
      IntPtr cPtr = NoesisGUI_PINVOKE.Shape_StrokeProperty_get();
      return (DependencyProperty)Noesis.Extend.GetProxy(cPtr, false);
    }
  }

  public static DependencyProperty StrokeDashArrayProperty {
    get {
      IntPtr cPtr = NoesisGUI_PINVOKE.Shape_StrokeDashArrayProperty_get();
      return (DependencyProperty)Noesis.Extend.GetProxy(cPtr, false);
    }
  }

  public static DependencyProperty StrokeDashCapProperty {
    get {
      IntPtr cPtr = NoesisGUI_PINVOKE.Shape_StrokeDashCapProperty_get();
      return (DependencyProperty)Noesis.Extend.GetProxy(cPtr, false);
    }
  }

  public static DependencyProperty StrokeDashOffsetProperty {
    get {
      IntPtr cPtr = NoesisGUI_PINVOKE.Shape_StrokeDashOffsetProperty_get();
      return (DependencyProperty)Noesis.Extend.GetProxy(cPtr, false);
    }
  }

  public static DependencyProperty StrokeEndLineCapProperty {
    get {
      IntPtr cPtr = NoesisGUI_PINVOKE.Shape_StrokeEndLineCapProperty_get();
      return (DependencyProperty)Noesis.Extend.GetProxy(cPtr, false);
    }
  }

  public static DependencyProperty StrokeLineJoinProperty {
    get {
      IntPtr cPtr = NoesisGUI_PINVOKE.Shape_StrokeLineJoinProperty_get();
      return (DependencyProperty)Noesis.Extend.GetProxy(cPtr, false);
    }
  }

  public static DependencyProperty StrokeMiterLimitProperty {
    get {
      IntPtr cPtr = NoesisGUI_PINVOKE.Shape_StrokeMiterLimitProperty_get();
      return (DependencyProperty)Noesis.Extend.GetProxy(cPtr, false);
    }
  }

  public static DependencyProperty StrokeStartLineCapProperty {
    get {
      IntPtr cPtr = NoesisGUI_PINVOKE.Shape_StrokeStartLineCapProperty_get();
      return (DependencyProperty)Noesis.Extend.GetProxy(cPtr, false);
    }
  }

  public static DependencyProperty StrokeThicknessProperty {
    get {
      IntPtr cPtr = NoesisGUI_PINVOKE.Shape_StrokeThicknessProperty_get();
      return (DependencyProperty)Noesis.Extend.GetProxy(cPtr, false);
    }
  }

  public static DependencyProperty TrimStartProperty {
    get {
      IntPtr cPtr = NoesisGUI_PINVOKE.Shape_TrimStartProperty_get();
      return (DependencyProperty)Noesis.Extend.GetProxy(cPtr, false);
    }
  }

  public static DependencyProperty TrimEndProperty {
    get {
      IntPtr cPtr = NoesisGUI_PINVOKE.Shape_TrimEndProperty_get();
      return (DependencyProperty)Noesis.Extend.GetProxy(cPtr, false);
    }
  }

  public static DependencyProperty TrimOffsetProperty {
    get {
      IntPtr cPtr = NoesisGUI_PINVOKE.Shape_TrimOffsetProperty_get();
      return (DependencyProperty)Noesis.Extend.GetProxy(cPtr, false);
    }
  }

  public Brush Fill {
    set {
      NoesisGUI_PINVOKE.Shape_Fill_set(swigCPtr, Brush.getCPtr(value));
    } 
    get {
      IntPtr cPtr = NoesisGUI_PINVOKE.Shape_Fill_get(swigCPtr);
      return (Brush)Noesis.Extend.GetProxy(cPtr, false);
    }
  }

  public Stretch Stretch {
    set {
      NoesisGUI_PINVOKE.Shape_Stretch_set(swigCPtr, (int)value);
    } 
    get {
      Stretch ret = (Stretch)NoesisGUI_PINVOKE.Shape_Stretch_get(swigCPtr);
      return ret;
    } 
  }

  public Brush Stroke {
    set {
      NoesisGUI_PINVOKE.Shape_Stroke_set(swigCPtr, Brush.getCPtr(value));
    } 
    get {
      IntPtr cPtr = NoesisGUI_PINVOKE.Shape_Stroke_get(swigCPtr);
      return (Brush)Noesis.Extend.GetProxy(cPtr, false);
    }
  }

  public string StrokeDashArray {
    set {
      NoesisGUI_PINVOKE.Shape_StrokeDashArray_set(swigCPtr, value != null ? value : string.Empty);
    }
    get {
      IntPtr strPtr = NoesisGUI_PINVOKE.Shape_StrokeDashArray_get(swigCPtr);
      string str = Noesis.Extend.StringFromNativeUtf8(strPtr);
      return str;
    }
  }

  public PenLineCap StrokeDashCap {
    set {
      NoesisGUI_PINVOKE.Shape_StrokeDashCap_set(swigCPtr, (int)value);
    } 
    get {
      PenLineCap ret = (PenLineCap)NoesisGUI_PINVOKE.Shape_StrokeDashCap_get(swigCPtr);
      return ret;
    } 
  }

  public float StrokeDashOffset {
    set {
      NoesisGUI_PINVOKE.Shape_StrokeDashOffset_set(swigCPtr, value);
    } 
    get {
      float ret = NoesisGUI_PINVOKE.Shape_StrokeDashOffset_get(swigCPtr);
      return ret;
    } 
  }

  public PenLineCap StrokeEndLineCap {
    set {
      NoesisGUI_PINVOKE.Shape_StrokeEndLineCap_set(swigCPtr, (int)value);
    } 
    get {
      PenLineCap ret = (PenLineCap)NoesisGUI_PINVOKE.Shape_StrokeEndLineCap_get(swigCPtr);
      return ret;
    } 
  }

  public PenLineJoin StrokeLineJoin {
    set {
      NoesisGUI_PINVOKE.Shape_StrokeLineJoin_set(swigCPtr, (int)value);
    } 
    get {
      PenLineJoin ret = (PenLineJoin)NoesisGUI_PINVOKE.Shape_StrokeLineJoin_get(swigCPtr);
      return ret;
    } 
  }

  public float StrokeMiterLimit {
    set {
      NoesisGUI_PINVOKE.Shape_StrokeMiterLimit_set(swigCPtr, value);
    } 
    get {
      float ret = NoesisGUI_PINVOKE.Shape_StrokeMiterLimit_get(swigCPtr);
      return ret;
    } 
  }

  public PenLineCap StrokeStartLineCap {
    set {
      NoesisGUI_PINVOKE.Shape_StrokeStartLineCap_set(swigCPtr, (int)value);
    } 
    get {
      PenLineCap ret = (PenLineCap)NoesisGUI_PINVOKE.Shape_StrokeStartLineCap_get(swigCPtr);
      return ret;
    } 
  }

  public float StrokeThickness {
    set {
      NoesisGUI_PINVOKE.Shape_StrokeThickness_set(swigCPtr, value);
    } 
    get {
      float ret = NoesisGUI_PINVOKE.Shape_StrokeThickness_get(swigCPtr);
      return ret;
    } 
  }

  public float TrimStart {
    set {
      NoesisGUI_PINVOKE.Shape_TrimStart_set(swigCPtr, value);
    } 
    get {
      float ret = NoesisGUI_PINVOKE.Shape_TrimStart_get(swigCPtr);
      return ret;
    } 
  }

  public float TrimEnd {
    set {
      NoesisGUI_PINVOKE.Shape_TrimEnd_set(swigCPtr, value);
    } 
    get {
      float ret = NoesisGUI_PINVOKE.Shape_TrimEnd_get(swigCPtr);
      return ret;
    } 
  }

  public float TrimOffset {
    set {
      NoesisGUI_PINVOKE.Shape_TrimOffset_set(swigCPtr, value);
    } 
    get {
      float ret = NoesisGUI_PINVOKE.Shape_TrimOffset_get(swigCPtr);
      return ret;
    } 
  }

  internal new static IntPtr Extend(string typeName) {
    return NoesisGUI_PINVOKE.Extend_Shape(Marshal.StringToHGlobalAnsi(typeName));
  }
}

}

