<p align="center">
  <img src="https://i.imgur.com/q0i4gey.png" width="270,2" height="251,3">
</p>

<h1 align="center">starDATA</h1>

![C#](https://img.shields.io/badge/C%23-Visual%20Studio-blue) ![.NET](https://img.shields.io/badge/.NET(Framework)-4.7.2-green) ![blender 2.9+](https://img.shields.io/badge/blender-version%202.9%2B-orange)

It would be nice if we could look at the stars as if they were small air balloons in our hands. Or can we actually?


# Contents

- [Summary](#summary)
- [Math](#mathimatics)


## Summary
**starData** - Windows Forms(.NET Framework) application, which allows you to:
+ read csv file with star([astronomical object](https://en.wikipedia.org/wiki/Star)) data;
+ generate a new star with **your** data settings;
+ convert to XYZ-coordinates;
+ simulate in blender(python scripts);
## Mathimatics  
Here's where the math kicks in. To find the distance between stars, we need to convert from the Earth-centered polar coordinate system astronomers use to a Cartesian X-Y-Z coordinate system. It sounds scary at first, but it really isn't. If you have spreadsheet software handy that can handle trig functions, it's very easy to create a spreadsheet that does all this for you.

Let's say what we have something like this in csv file:
```bash
S_RA_T	         S_DEC_T	 S_DISTANCE
16 10 24.5074	 +43 48 58.9036	 17.9323
```
