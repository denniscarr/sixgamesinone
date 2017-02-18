using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class TextParserScript : MonoBehaviour {

	public string fileName = "codeSnippets.txt";

	public List<string> codeBits;

	// Use this for initialization
	void Start () {

		Debug.Log ("Path: " + Application.dataPath);

		string finalFilePath = Application.dataPath + "/" + fileName;

		// write to a file -- testing purposes only
		StreamWriter sw = new StreamWriter(finalFilePath, false);

		for (int i = 0; i < codeBits.Count; i++) {
			sw.WriteLine (codeBits[i] + i);
		}

		sw.Close ();

		// read from a file
		StreamReader sr = new StreamReader(finalFilePath, false);

		int j = 0;

		while (!sr.EndOfStream) {
			string line = sr.ReadLine ();

			string[] splitLine = line.Split (';');

			string lines = splitLine [0];
			codeBits.Add (lines);

			j++;
		}

		sr.Close();
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
