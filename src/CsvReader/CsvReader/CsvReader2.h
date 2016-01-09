#pragma once

#include <assert.h>
#include <fstream>
#include <iostream>
#include <sstream>
#include <vector>
#include <string>

using namespace std;

template <class T>
class CsvReader2
{
public:
	CsvReader2(const char *pszFilename) : m_strFilename(pszFilename)
	{ }

	~CsvReader2(void) { }

	vector<T> TransformData();

private:
	stringstream ReadFileContents();
	T ConvertLine2Data(const string& line);

private:
	string m_strFilename;
};

template <class T>
vector<T> CsvReader2<T>::TransformData()
{
	stringstream ss = ReadFileContents();
	vector<T> result;
	string line;

	while(!ss.eof())
	{
		ss >> line;
		result.emplace_back(ConvertLine2Data(line));
	}

	return result;
}

template <class T>
stringstream CsvReader2<T>::ReadFileContents()
{
	assert(!m_strFilename.empty());
	if(!m_strFilename.empty())
	{
		ifstream file(m_strFilename);
		if(file.good())
		{
			stringstream ss;
			ss << file.rdbuf();
			return ss;
		}
		else
		{
			cerr << "Error opening file " << m_strFilename << endl;
		}
	}
	else
	{
		cerr << "Error : Filename not specified." << endl;
	}

	throw ifstream::failure("Error processing file");
}


template <class T>
T CsvReader2<T>::ConvertLine2Data(const string& line)
{
	return T();
}

