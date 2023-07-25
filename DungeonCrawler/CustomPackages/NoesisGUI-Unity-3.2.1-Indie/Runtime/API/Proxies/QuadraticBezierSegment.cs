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

public class QuadraticBezierSegment : PathSegment {
  internal new static QuadraticBezierSegment CreateProxy(IntPtr cPtr, bool cMemoryOwn) {
    return new QuadraticBezierSegment(cPtr, cMemoryOwn);
  }

  internal QuadraticBezierSegment(IntPtr cPtr, bool cMemoryOwn) : base(cPtr, cMemoryOwn) {
  }

  internal static HandleRef getCPtr(QuadraticBezierSegment obj) {
    return (obj == null) ? new HandleRef(null, IntPtr.Zero) : obj.swigCPtr;
  }

  public QuadraticBezierSegment() {
  }

  protected override IntPtr CreateCPtr(Type type, out bool registerExtend) {
    registerExtend = false;
    return NoesisGUI_PINVOKE.new_QuadraticBezierSegment__SWIG_0();
  }

  public QuadraticBezierSegment(Point point1, Point point2, bool isStroked) : this(NoesisGUI_PINVOKE.new_QuadraticBezierSegment__SWIG_1(ref point1, ref point2, isStroked), true) {
  }

  public static DependencyProperty Point1Property {
    get {
      IntPtr cPtr = NoesisGUI_PINVOKE.QuadraticBezierSegment_Point1Property_get();
      return (DependencyProperty)Noesis.Extend.GetProxy(cPtr, false);
    }
  }

  public static DependencyProperty Point2Property {
    get {
      IntPtr cPtr = NoesisGUI_PINVOKE.QuadraticBezierSegment_Point2Property_get();
      return (DependencyProperty)Noesis.Extend.GetProxy(cPtr, false);
    }
  }

  public Point Point1 {
    set {
      NoesisGUI_PINVOKE.QuadraticBezierSegment_Point1_set(swigCPtr, ref value);
    }

    get {
      IntPtr ret = NoesisGUI_PINVOKE.QuadraticBezierSegment_Point1_get(swigCPtr);
      if (ret != IntPtr.Zero) {
        return Marshal.PtrToStructure<Point>(ret);
      }
      else {
        return new Point();
      }
    }

  }

  public Point Point2 {
    set {
      NoesisGUI_PINVOKE.QuadraticBezierSegment_Point2_set(swigCPtr, ref value);
    }

    get {
      IntPtr ret = NoesisGUI_PINVOKE.QuadraticBezierSegment_Point2_get(swigCPtr);
      if (ret != IntPtr.Zero) {
        return Marshal.PtrToStructure<Point>(ret);
      }
      else {
        return new Point();
      }
    }

  }

}

}

