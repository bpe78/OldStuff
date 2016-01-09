#pragma once

#include <assert.h>

double naiveAtoF(const char *p)
{
    double r = 0.0;
    bool neg = false;

		if (*p == '-')
		{
        neg = true;
        ++p;
    }
    while (*p >= '0' && *p <= '9')
		{
        r = (r*10.0) + (*p - '0');
        ++p;
    }
    if (*p == '.')
		{
        double f = 0.0;
        int n = 0;
        ++p;
        while (*p >= '0' && *p <= '9')
				{
            f = (f*10.0) + (*p - '0');
            ++p;
            ++n;
        }

				r += f / std::pow(10.0, n);
    }
    if (neg)
		{
        r = -r;
    }
    return r;
}

struct Example1
{
	Example1(void) :m_iId(), m_carrCategory(), m_carrParameterName(), m_dfValue()
	{
	}

	Example1(int iTokenCount, const char *parrTokenStart[], const char *parrTokenEnd[])
	{
		assert(iTokenCount == 4);

		size_t sizeSource; 
		char carrTmp[20];

		// Convert string to int
		sizeSource = parrTokenEnd[0] - parrTokenStart[0];
		assert(sizeSource < _countof(carrTmp));
		memcpy_s(carrTmp, sizeof(carrTmp), parrTokenStart[0], sizeSource);
		carrTmp[sizeSource] = 0;
		m_iId = atoi(carrTmp);

		// Copy string
		sizeSource = parrTokenEnd[1] - parrTokenStart[1];
		assert(sizeSource < _countof(m_carrCategory));
		memcpy_s(m_carrCategory, sizeof(m_carrCategory), parrTokenStart[1], sizeSource);
		m_carrCategory[sizeSource] = 0;

		// Copy string
		sizeSource = parrTokenEnd[2] - parrTokenStart[2];
		assert(sizeSource < _countof(m_carrParameterName));
		memcpy_s(m_carrParameterName, sizeof(m_carrParameterName), parrTokenStart[2], sizeSource);
		m_carrParameterName[sizeSource] = 0;

		// Convert string to double
		sizeSource = parrTokenEnd[3] - parrTokenStart[3];
		assert(sizeSource < _countof(carrTmp));
		memcpy_s(carrTmp, sizeof(carrTmp), parrTokenStart[3], sizeSource);
		carrTmp[sizeSource] = 0;
		m_dfValue = atof(carrTmp);
		//m_dfValue = naiveAtoF(carrTmp);
	}

	~Example1(void)
	{
	}

	int m_iId;
	char m_carrCategory[40];
	char m_carrParameterName[40];
	double m_dfValue;
};

