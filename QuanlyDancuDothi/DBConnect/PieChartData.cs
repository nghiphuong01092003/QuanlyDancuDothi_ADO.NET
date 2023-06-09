using LiveCharts;
using LiveCharts.Defaults;
using LiveCharts.Wpf;
using QuanlyDancuDothi.ClassDAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanlyDancuDothi.DBConnect
{
    public class PieChartData
    {
        TrangChuDAO tcDao = new TrangChuDAO();
        public SeriesCollection GioiTinhData()
        {
            SeriesCollection seriesViews = new SeriesCollection
            {
                new PieSeries
                {
                    Title = "Nam",
                    Values = new ChartValues<ObservableValue> {new ObservableValue(tcDao.DemSoCongDanNam())},
                    DataLabels = true
                },
                new PieSeries
                {
                    Title = "Nữ",
                    Values = new ChartValues<ObservableValue> {new ObservableValue(tcDao.DemSoCongDanNu())},
                    DataLabels = true
                }
            };
            return seriesViews;
        }
        public SeriesCollection KetHonData()
        {
            SeriesCollection seriesViews = new SeriesCollection
            {
                new PieSeries
                {
                    Title = "Đã kết hôn",
                    Values = new ChartValues<ObservableValue> {new ObservableValue(tcDao.DemSoCongDanDaKetHon())},
                    DataLabels = true
                },
                new PieSeries
                {
                    Title = "Chưa kết hôn",
                    Values = new ChartValues<ObservableValue> {new ObservableValue(tcDao.DemSoCongDan() - tcDao.DemSoCongDanDaKetHon())},
                    DataLabels = true
                }
            };
            return seriesViews;
        }
        public SeriesCollection LyHonData()
        {
            SeriesCollection seriesViews = new SeriesCollection
            {
                new PieSeries
                {
                    Title = "Đã ly hôn",
                    Values = new ChartValues<ObservableValue> {new ObservableValue(tcDao.DemSoCongDanDaLyHon())},
                    DataLabels = true
                },
                new PieSeries
                {
                    Title = "Chưa ly hôn",
                    Values = new ChartValues<ObservableValue> {new ObservableValue(tcDao.DemSoCongDanDaKetHon() - tcDao.DemSoCongDanDaLyHon())},
                    DataLabels = true
                }
            };
            return seriesViews;
        }
    }
}
