///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
// Copyright (C) 2017 Gambusino Labs - All Rights Reserved
// Unauthorized copying of this file, via any medium is strictly prohibited
// Proprietary and confidential
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
// Name                          Date                Description
// --------------------------------------------------------------------------------------------------------------------------------
// Maximetinu                    5/1/2017            Created.
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
using UnityEngine;

/// <summary>
/// Clase estatica para usar en lugar de Color con más colores que esta última sin necesidad de hacer el Lerp.
/// </summary>
public static class ColorExtension {
	private static float softT = .25f;
	private static float hardT = .75f;

	public static Color black = Color.black;
	public static Color blackClear = Clear(black);
	public static Color blackClearer = Clearer(black);

	public static Color gray = Color.gray;
	public static Color grayDark = Dark(gray);
	public static Color grayDarker = Darker(gray);
	public static Color grayLight = Light(gray);
	public static Color grayLighter = Lighter(gray);
	public static Color grayClear = Clear(gray);
	public static Color grayClearer = Clearer(gray);

	public static Color grey = Color.grey;
	public static Color greyDark = Dark(grey);
	public static Color greyDarker = Darker(grey);
	public static Color greyLight = Light(grey);
	public static Color greyLighter = Lighter(grey);
	public static Color greyClear = Clear(grey);
	public static Color greyClearer = Clearer(grey);

	public static Color white = Color.white;
	public static Color whiteClear = Clear(white);
	public static Color whiteClearer = Clearer(white);

	public static Color red = Color.red;
	public static Color redDark = Dark(red);
	public static Color redDarker = Darker(red);
	public static Color redLight = Light(red);
	public static Color redLighter = Lighter(red);
	public static Color redClear = Clear(red);
	public static Color redClearer = Clearer(red);

	public static Color green = Color.green;
	public static Color greenDark = Dark(green);
	public static Color greenDarker = Darker(green);
	public static Color greenLight = Light(green);
	public static Color greenLighter = Lighter(green);
	public static Color greenClear = Clear(green);
	public static Color greenClearer = Clearer(green);

	public static Color blue = Color.blue;
	public static Color blueDark = Dark(blue);
	public static Color blueDarker = Darker(blue);
	public static Color blueLight = Light(blue);
	public static Color blueLighter = Lighter(blue);
	public static Color blueClear = Clear(blue);
	public static Color blueClearer = Clearer(blue);

	public static Color yellow = Color.yellow;
	public static Color yellowDark = Dark(yellow);
	public static Color yellowDarker = Darker(yellow);
	public static Color yellowLight = Light(yellow);
	public static Color yellowLighter = Lighter(yellow);
	public static Color yellowClear = Clear(yellow);
	public static Color yellowClearer = Clearer(yellow);

	public static Color cyan = Color.cyan;
	public static Color cyanDark = Dark(cyan);
	public static Color cyanDarker = Darker(cyan);
	public static Color cyanLight = Light(cyan);
	public static Color cyanLighter = Lighter(cyan);
	public static Color cyanClear = Clear(cyan);
	public static Color cyanClearer = Clearer(cyan);

	public static Color magenta = Color.magenta;
	public static Color magentaDark = Dark(magenta);
	public static Color magentaDarker = Darker(magenta);
	public static Color magentaLight = Light(magenta);
	public static Color magentaLighter = Lighter(magenta);
	public static Color magentaClear = Clear(magenta);
	public static Color magentaClearer = Clearer(magenta);

	public static Color clear = Color.clear;

	private static System.Random random = new System.Random();

	private static float GetRandomBetween0And1() {
		return (float)(random.NextDouble() * (1f - 0f) + 0f);
	}

	private static int GetRandomBetween(int min, int max) {
		return random.Next() % max + min;
	}

	public static Color Random(float alpha = 1.0f) {
		return new Color(GetRandomBetween0And1(), GetRandomBetween0And1(), GetRandomBetween0And1(),alpha);
	}

	public static Color RandomMain() {
		int selected = GetRandomBetween(0, 5);
		switch (selected) {
		case 0: return Color.red;
		case 1: return Color.blue;
		case 2: return Color.yellow;
		case 3: return Color.magenta;
		case 4: return Color.green;
		case 5: return Color.cyan;
		default: return Color.black;
		}
	}

	public static Color RandomMain(Color avoid) {
		Color selectedColor;
		int selected;
		tryagain:
		selected = GetRandomBetween(0, 5);
		switch (selected) {
		case 0: selectedColor = Color.red; break;
		case 1: selectedColor = Color.blue; break;
		case 2: selectedColor = Color.yellow; break;
		case 3: selectedColor = Color.magenta; break;
		case 4: selectedColor = Color.green; break;
		case 5: selectedColor = Color.cyan; break;
		default: selectedColor = Color.black; break;
		}
		if (selectedColor == avoid)
			goto tryagain;
		return selectedColor;
	}

	public static Color Lerp(Color a, Color b, float t) {
		return Color.LerpUnclamped(a, b, t);
	}

	public static Color Dark(Color c) {
		return Color.LerpUnclamped(c, Color.black, softT);
	}

	public static Color Darker(Color c) {
		return Color.LerpUnclamped(c, Color.black, hardT);
	}

	public static Color Light(Color c) {
		return Color.LerpUnclamped(c, Color.white, softT);
	}

	public static Color Lighter(Color c) {
		return Color.LerpUnclamped(c, Color.white, hardT);
	}

	public static Color Clear(Color c) {
		return Color.LerpUnclamped(c, Color.clear, softT);
	}

	public static Color Clearer(Color c) {
		return Color.LerpUnclamped(c, Color.clear, hardT);
	}

	public static Color Opacity(Color c, float a) {
		return Color.LerpUnclamped(Color.clear, c, a);
	}
}