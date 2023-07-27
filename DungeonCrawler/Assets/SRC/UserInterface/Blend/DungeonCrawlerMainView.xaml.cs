#if UNITY_5_3_OR_NEWER
#define NOESIS
using Noesis;
#else
using System;
using System.Windows.Controls;
#endif

namespace DungeonCrawler
{
    /// <summary>
    /// Interaction logic for DungeonCrawlerMainView.xaml
    /// </summary>
    public partial class DungeonCrawlerMainView : UserControl
    {
        public DungeonCrawlerMainView()
        {
            InitializeComponent();
        }

#if NOESIS
        private void InitializeComponent()
        {
            NoesisUnity.LoadComponent(this);
        }
#endif
    }
}
