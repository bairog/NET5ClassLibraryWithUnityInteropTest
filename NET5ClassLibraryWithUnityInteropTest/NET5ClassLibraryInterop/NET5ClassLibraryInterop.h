#pragma once

#ifdef CREATE_INTEROP_LIB
#ifndef INTEROP_LIB
#define INTEROP_LIB __declspec( dllexport)
#endif
#else
#ifndef INTEROP_LIB
#define INTEROP_LIB __declspec( dllimport)
#endif
#endif

#include <cstdint>

namespace NET5ClassLibraryInterop {
	class INTEROP_LIB NET5nterop
	{
	public:
		/*!
		* \brief  ��������� ������� VACUUM ��� ���������� ������� �� ����� �������� ������� �� ��
		*
		*  \return ���������� ���������� �������� �����
		*/
		static std::int32_t GetInt();
		static double GetDouble();
	};
}
