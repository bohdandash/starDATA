<p align="center">
  <img src="https://i.imgur.com/q0i4gey.png" width="270,2" height="251,3">
</p>

<h1 align="center">starDATA</h1>

![C#](https://img.shields.io/badge/C%23-Visual%20Studio-blue) ![.NET](https://img.shields.io/badge/.NET(Framework)-4.7.2-green) ![blender 2.9+](https://img.shields.io/badge/blender-version%202.9%2B-orange)

It would be nice if we could look at the stars as if they were small air balloons in our hands. Or can we actually?


# Contents

- [Summary](#summary)
- [Math](#mathimatics)
- [Usage](#usage)


## Summary
**starData** - Windows Forms(.NET Framework) application, which allows you to:
+ read csv file with star([astronomical object](https://en.wikipedia.org/wiki/Star)) data;
+ generate a new star with **your** data settings;
+ convert to XYZ-coordinates;
+ simulate in blender(python scripts);
## Mathimatics  
Here's where the math kicks in. To find the distance between stars, we need to convert from the Earth-centered polar coordinate system astronomers use to a Cartesian X-Y-Z coordinate system. It sounds scary at first, but it really isn't. If you have spreadsheet software handy that can handle trig functions, it's very easy to create a spreadsheet that does all this for you.

Let's say what we have something like this in csv file:

| S_RA        | S_DEC       | S_DISTANCE  |
| ------------- |:-------------:| :-----:|
| 16 10 24.5074      | +43 48 58.9036 | 17.9323 |

**S_RA** - star right ascension (hours minutes seconds);
**S_DEC** - star declination(degrees minutes seconds);
**S_DISTANCE** - star distance (parsecs);

First, we need to convert S_RA to degrees(***just to one number***). We'll call this value A:
```bash
A = (hours * 15) + (minutes * 0.25) + (seconds * 0.004166)
```
> (hours * 15) = _The total number of hours is multiplied by 15 degrees, since one hour of RA is 15 degrees._

> (minutes * 0.25) - _The total number of minutes is multiplied by 0.25, since 0.25 represents 1/4 hour, since 1 hour = 60 minutes = 4 quarters._

> (seconds * 0.004166) - _The total number of seconds is multiplied by 0.004166, since 0.004166 represents 1/240 of an hour, 'cause 1 hour = 3600 seconds = 240 parts._

In our case:
```bash
A = (16 * 15) + (10 * 0.25) + (24.5074 * 0.004166) = 242.602
```

Second, we need to find the value of what we'll call B. As declination is already measured in degrees, this is pretty simple:
```bash
B = ( ABS(Dec_degrees) + (Dec_minutes / 60) + (Dec_seconds / 3600)) * SIGN(Dec_Degrees)
```
> ABS() - _absolute value(returns only +)._

> SIGN() - _If the number is positive, then the function will return 1, if the number is negative, then the function will return -1, and if the number is 0, then the function will return 0._

In our case:
```bash
B = ( ABS(+43) + (48/60) + (58.9036/3600)) * SIGN(+43) = 43.016
```

Next, we need to find the value of C, it's just the distance in light years. You can use parsecs if you prefer. **But dont combine** light years with one star and parsecs with the other, **though!**:

```bash
C = S_DISTANCE = 17.9323(In our case)
```

Now that we have all our polar coordinates in the same units, we can convert that to Cartesian X-Y-Z coordinates using formulas:

```bash
X = (C * cos(B)) * cos(A);

Y = (C * cos(B)) * sin(A);

Z = C * sin(B);
```

Using values for A, B, and C for each star, plugging in our numbers gives us:

```bash
X = -7.79930028290825;

Y = -6,56080735472538;

Z = -14,7544605201684;
```

## Usage
