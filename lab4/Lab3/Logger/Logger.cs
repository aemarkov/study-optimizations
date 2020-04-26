using System;
using System.Text;
using System.Diagnostics;
using System.IO;	

namespace SimpleLogger
{
	/// <summary>
	/// Отвечает за логгированеи
	/// </summary>
	public class Logger
	{
		// События оповещения
		public delegate void MessageWritedDelegate(string message);
		public static event MessageWritedDelegate MessageWrited;

		//Настраиваемые параметры
		string _filename;                                   // Имя файла
		bool _logToDebug;                                   // Выводить лог в Debug Output
		bool _addDateTime;                                  // Печатать дату и время перед сообщениями
		string _dateTimeFormat;                             // Формат даты и времени

		bool _isBlockBegan;

		//////////////// SINGLETONE /////////////////////////////////////////////////////


		private static volatile Logger _instance;			// Экземпляр логгера
		private static object _syncRoot = new object();     // Объект синхронизации

		// Конструктор с параметрами по-умолчанию
		private Logger()
		{
			_logToDebug = false;
			_isBlockBegan = false;
		}

		// Конструктор с настройками
		private Logger(string filename, bool logToDebug, bool addDateTime, string dateTimeFormat):this()
		{
			_logToDebug = logToDebug;
			_addDateTime = addDateTime;
			_dateTimeFormat = dateTimeFormat;

			//Определяем имя файла
			if (filename != null)
				_filename = filename;
			else
				_filename = DateTime.Now.ToString(_dateTimeFormat).Replace(" ", "___").Replace(':', '_').Replace('.', '_') +".txt";
		}

		// Возвращает или создает и возвращает экземпляр
		public static Logger Instance
		{
			get
			{
				if (_instance == null)
				{
					lock (_syncRoot)
					{
						if (_instance == null)
							_instance = new Logger();
					}
				}
				return _instance;
			}
		}

		/// <summary>
		///  Настройка логгера.
		/// Должна выполняться до вызова всех фунций логгера
		/// Попытка настроить уже созданный логгер приведет к исключению
		/// </summary>
		public static void Setup(string filename = null,
								 bool logToDebug=false,
								 bool addDateTime = true,
								 string dateTimeFormat="yyyy.mm.dd HH:mm:ss")
		{
			if (_instance == null)
			{
				lock (_syncRoot)
				{
					if (_instance == null)
						_instance = new Logger(filename, logToDebug, addDateTime, dateTimeFormat);
					else
						throw new LoggerAlreadySetupException();
				}
			}
			else
				throw new LoggerAlreadySetupException();
		}

		

		///////////// INTERFACE /////////////////////////////////////////////////////

		/// <summary>
		/// Записывает строку в лог в новый блок
		/// </summary>
		/// <param name="format">Форматная строка для записи</param>
		/// <param name="args">Объекты для записи</param>
		public static void Write(string format, params Object[] args)
		{
			Instance._write(format, true, args);
		}

		/// <summary>
		/// Записывает строку в лог в текущий блок
		/// </summary>
		/// <param name="format">Форматная строка для записи</param>
		/// <param name="args">Объекты для записи</param>
		public static void WriteContinue(string format, params Object[] args)
		{
			Instance._write(format, false, args);
		}

		/// <summary>
		/// Пишет строку в лог в новый блок
		/// </summary>
		/// <param name="message"></param>
		public static void Write(string message)
		{
			Instance._write(message, true);
		}

		/// <summary>
		/// Пишет строку в лог в текущий блок
		/// </summary>
		/// <param name="message"></param>
		public static void WriteContinue(string message)
		{
			Instance._write(message, false);
		}

		//////////// REALISATION ////////////////////////////////////////////////////]

		// Пишет в лог форматированную строку
		private void _write(string format, bool isNewBlock, params Object[] args)
		{
			//Форматирует строку и передаем в простой метод
			_write(String.Format(format, args), isNewBlock);
		}

		//Пишет в лог простую строку
		private void _write(string message, bool isNewBlock)
		{
			//Добавляем отступ блок
			string str = _blockWork(message, isNewBlock) + Environment.NewLine;

			//Добавляем время
			if (_addDateTime)
				str = DateTime.Now.ToString(_dateTimeFormat) + "   " + str;

			//Пишем в консоль, если надо
			if (_logToDebug)
				Debug.Write(str);

			//Пищем в файл
			File.AppendAllText(_filename, str, Encoding.UTF8);

			//Оповещаем подписчиков
			if(MessageWrited!=null)
				MessageWrited(str);
		}


		//Управление отступами в блоках
		private string _blockWork(string logstr, bool isNewBlock)
		{
			if (isNewBlock || !_isBlockBegan)
			{
				_isBlockBegan = true;
				return "> " + logstr;
			}
			else
				return "  " + logstr;
		}
	}
}
