using UnityEngine;

namespace akihiro.bodytracking.Pictogram
{
    /// <summary>
    /// Pictogramモデルと小物の表示，非表示切り替え機能
    /// Space : 下半身の表示，非表示
    /// 左Shift : 腰の表示，非表示
    /// 左Control : 胸の表示，非表示
    /// Z, X : カメラの90度回転
    /// 1 : 左手にボール
    /// 2 : 右手にボール
    /// 3 : 床にボール
    /// 4 : 空中にボール
    /// 5 : 砂場(カメラを90度回転)
    /// 6 : ウェイトリフティング
    /// 7 : 右手にラケット
    /// 8 : 崖
    /// 9 : 天井に棒(カメラを180度回転)
    /// 0 : 青色の波
    /// Q : 白色の波
    /// W : リボン
    /// E : 左手に棒
    /// R : 右手に棒
    /// T : 右足にボード
    /// Y : ウマ
    /// U : ボート(白色の波と合わせて)
    /// I : 左手に弓
    /// O : 自転車
    /// </summary>
    public class PictogramControl : MonoBehaviour
    {
        [Header("Body")]
        [SerializeField] private Transform head;
        [SerializeField] private Transform neck;
        [SerializeField] private Transform chest;
        [SerializeField] private Transform righthand;
        [SerializeField] private Transform lefthand;
        [SerializeField] private Transform rightHip;
        [SerializeField] private Transform rightKnee;
        [SerializeField] private Transform rightAnkle;
        [SerializeField] private Transform leftHip;
        [SerializeField] private Transform leftKnee;
        [SerializeField] private Transform leftAnkle;
        [Header("Material")]
        [SerializeField] private Material blue;
        [SerializeField] private Material white;
        [Header("Tools")]
        [SerializeField] private Transform BallL;
        [SerializeField] private Transform BallR;
        [SerializeField] private Transform BallD;
        [SerializeField] private Transform BallU;
        [SerializeField] private Transform ground;
        [SerializeField] private Transform weight;
        [SerializeField] private Transform racket;
        [SerializeField] private Transform clim;
        [SerializeField] private Transform line;
        [SerializeField] private Transform waveB;
        [SerializeField] private Transform waveW;
        [SerializeField] private Transform rope;
        [SerializeField] private Transform stickL;
        [SerializeField] private Transform stickR;
        [SerializeField] private Transform board;
        [SerializeField] private Transform house;
        [SerializeField] private Transform hune;
        [SerializeField] private Transform arch;
        [SerializeField] private Transform cyclue;
        [Header("Camera")]
        [SerializeField] private Camera cam;

        private bool isChest = false;
        private bool isNeck = false;

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            // 下半身表示，非表示
            if (Input.GetKeyUp(KeyCode.Space))
            {
                rightHip.gameObject.SetActive(!rightHip.gameObject.activeSelf);
                rightKnee.gameObject.SetActive(!rightKnee.gameObject.activeSelf);
                rightAnkle.gameObject.SetActive(!rightAnkle.gameObject.activeSelf);

                leftHip.gameObject.SetActive(!leftHip.gameObject.activeSelf);
                leftKnee.gameObject.SetActive(!leftKnee.gameObject.activeSelf);
                leftAnkle.gameObject.SetActive(!leftAnkle.gameObject.activeSelf);
            }
            // 腰表示，非表示
            if (Input.GetKeyUp(KeyCode.LeftShift))
            {
                isChest = !isChest;
                var mat = chest.GetComponent<Renderer>();
                mat.material = isChest ? blue : white;
            }
            // 胸表示，非表示
            if (Input.GetKeyUp(KeyCode.LeftControl))
            {
                isNeck = !isNeck;
                var mat = neck.GetComponent<Renderer>();
                mat.material = isNeck ? blue : white;
            }
            // カメラ90度回転
            if (Input.GetKeyDown(KeyCode.Z)) cam.transform.rotation *= Quaternion.Euler(0, 0, 90);
            if (Input.GetKeyDown(KeyCode.X)) cam.transform.rotation *= Quaternion.Euler(0, 0, -90);
            // 小物表示，非表示
            setPoint(KeyCode.Alpha1, BallL, lefthand);
            setPoint(KeyCode.Alpha2, BallR, righthand);
            setPoint(KeyCode.Alpha3, BallD);
            setPoint(KeyCode.Alpha4, BallU);
            setPoint(KeyCode.Alpha5, ground);
            setPoint(KeyCode.Alpha6, weight);
            setPoint(KeyCode.Alpha7, racket, righthand);
            setPoint(KeyCode.Alpha8, clim);
            setPoint(KeyCode.Alpha9, line);
            setPoint(KeyCode.Alpha0, waveB);
            setPoint(KeyCode.Q, waveW);
            setPoint(KeyCode.W, rope);
            setPoint(KeyCode.E, stickL, lefthand);
            setPoint(KeyCode.R, stickR, righthand);
            setPoint(KeyCode.T, board, rightAnkle);
            setPoint(KeyCode.Y, house, chest);
            setPoint(KeyCode.U, hune);
            setPoint(KeyCode.I, arch, lefthand);
            setPoint(KeyCode.O, cyclue, chest);
        }

        private void setPoint(KeyCode key, Transform source, Transform target = null)
        {
            if (Input.GetKeyUp(key)) source.gameObject.SetActive(!source.gameObject.activeSelf);
            if (source.gameObject.activeSelf && target != null) source.SetPositionAndRotation(target.position, target.rotation);
        }
    }
}
