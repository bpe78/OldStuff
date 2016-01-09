// CsvReader.cpp : Defines the entry point for the console application.
//

#include "stdafx.h"
#include <fstream>
#include <sstream>
#include <string>
#include <iostream>
#include <chrono>
#include <assert.h>
#include <vector>
#include <algorithm>
#include "Example1.h"
#include "CsvReader2.h"

using namespace std;
using namespace std::chrono;

bool tokenize(const char *pszLine, int countExpectedTokens, const char *parrTokenStart[], const char *parrTokenEnd[])
{
	assert(pszLine != nullptr);
	if(pszLine == nullptr) throw invalid_argument("pszLine must not be NULL.");
	if(parrTokenStart == nullptr) throw invalid_argument("parrTokenStart must not be NULL.");
	if(parrTokenEnd == nullptr) throw invalid_argument("parrTokenEnd must not be NULL.");

	try
	{
		//vector<const char *> vecTokenStartPos, vecTokenEndPos;
		//vecTokenStartPos.reserve(countExpectedTokens);
		//vecTokenEndPos.reserve(countExpectedTokens);
		bool isTokenStart = true, isEOL = false;
		int quotesInToken = 0;
		int iCurrentToken = 0;

		const char *p = pszLine;
		//vecTokenStartPos.emplace_back(p);
		parrTokenStart[iCurrentToken] = p;
		do
		{
			switch(*p)
			{
			case '\0' :
			case '\r' :
			case '\n' :
				{
					// End of line, check conditions
					if(quotesInToken % 2 != 0)
						throw bad_exception("Invalid token, missing end quote.");

					// End of current token
					//vecTokenEndPos.emplace_back(p);
					parrTokenEnd[iCurrentToken] = p;
					isEOL = true;
				} break;

			case ',' :
				{
					if(quotesInToken % 2 == 0)
					{
						// End of current token
						//vecTokenEndPos.emplace_back(p);
						parrTokenEnd[iCurrentToken] = p;

						// Start next token
						++iCurrentToken;
						//vecTokenStartPos.emplace_back(p + 1);
						parrTokenStart[iCurrentToken] = p + 1;
						isTokenStart = true;
						quotesInToken = 0;
					}
				} break;

			case '"' :
				{
					++quotesInToken;
				} break;

			default : break;
			}

			++p;
		} while(!isEOL);

		///////// Debug
		/*char debugData[10][64] = {0};
		for (int i = 0; i <= iCurrentToken; ++i)
		{
		memcpy_s(debugData[i], _countof(debugData[i]), vecTokenStartPos[i], vecTokenEndPos[i] - vecTokenStartPos[i]);
		}
		cout << debugData[0] << " --- " << debugData[1] << " --- " << debugData[2] << " --- " << debugData[3] << " --- " << debugData[4] << " --- " << debugData[5] << " --- " << endl;*/
	}
	catch(exception ex)
	{
		cout << ex.what() << endl;
		return false;
	}
	///////// Debug
	return true;
}

int _tmain(int argc, _TCHAR* argv[])
{


	const char szFilename[] = "g:\\test.csv";

	CsvReader2<Example1> reader(szFilename);
	vector<Example1> vec = reader.TransformData();
}

/*int _tmain(int argc, _TCHAR* argv[])
{
	const char szFilename[] = "g:\\test.csv";

	stringstream ss;
	vector<Example1> vecData;
	vecData.reserve(100000);

	high_resolution_clock::time_point t1, t2, t3;
	t1 = high_resolution_clock::now();

	ifstream input(szFilename, ios::in);
	if(input.good())
	{
		ss << input.rdbuf();

		input.close();

		t2 = high_resolution_clock::now();
		char line[256];
		// Read header
		//ss.getline(line, _countof(line));

		const int EXPECTED_TOKENS = 4;
		const char *arrTokenStart[EXPECTED_TOKENS], *arrTokenEnd[EXPECTED_TOKENS];
		while(ss.getline(line, _countof(line)))
		{
			if(tokenize(line, EXPECTED_TOKENS, arrTokenStart, arrTokenEnd))
				vecData.emplace_back(Example1(EXPECTED_TOKENS, arrTokenStart, arrTokenEnd));
		}
	}

	t3 = high_resolution_clock::now();

	std::cout << "It took me " << duration_cast<milliseconds>(t2 - t1).count() << " ms to read the file contents." << endl;
	std::cout << "It took me " << duration_cast<milliseconds>(t3 - t2).count() << " ms to tokenize the contents." << endl;
	std::cout << "It took me " << duration_cast<milliseconds>(t3 - t1).count() << " ms overall." << endl;

	return 0;
}*/

