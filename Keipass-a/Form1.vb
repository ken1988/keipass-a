Public Class frmMain

    Private Sub frmMain_Load(sender As Object, e As EventArgs) Handles Me.Load
        Try
            Dim sid As String
            Dim IReturnCode As Long

            '引数設定
            sid = "Keipass"

            'JV Link初期化
            IReturnCode = Me.AxJVLink1.JVInit(sid)

            If IReturnCode <> 0 Then
                MsgBox("JVinitエラー コード:" & IReturnCode & "：", MessageBoxIcon.Error)
                Me.Cursor = System.Windows.Forms.Cursor.Current

            End If

            'コマンドライン引数取得
            If Environment.GetCommandLineArgs.GetValue(1).ToString = "A" Then
                Dim Races As New ArrayList
                Races = GetJVRace()
            Else

            End If
        Catch ex As Exception


        End Try
    End Sub
    Private Sub mnuConfJV_Click(sender As Object, e As EventArgs) Handles mnuConfJV.Click
        Try
            'リターンコード
            Dim IReturnCode As Long

            '設定画面表示
            IReturnCode = AxJVLink1.JVSetUIProperties

            If IReturnCode <> 0 Then
                MsgBox("JVSetUIPropertiesエラー()コード:" & IReturnCode & "：", MessageBoxIcon.Error)
            End If

        Catch ex As Exception

        End Try
    End Sub
    Private Sub btnGetJVData_Click(sender As Object, e As EventArgs) Handles btnGetJVData.Click

        Dim Races As New ArrayList
        Dim RaceInfo As JV_RA_RACE
        Dim strRaceID As String

        Races = GetJVRace()

        ProgressBar.Maximum = Races.Count
        ProgressBar.Minimum = 0
        ProgressBar.Step = 1
        For Each RaceInfo In Races
            'データ表示
            strRaceID = RaceInfo.id.Year & RaceInfo.id.MonthDay & RaceInfo.id.JyoCD & RaceInfo.id.Kaiji & RaceInfo.id.Nichiji & RaceInfo.id.RaceNum
            ListRace.Items.Add(strRaceID)
            rtbData.AppendText("年:" & RaceInfo.id.Year & "月日:" & RaceInfo.id.MonthDay & "場:" & RaceInfo.id.JyoCD & _
                               "回次:" & RaceInfo.id.Kaiji & "日次:" & RaceInfo.id.Nichiji & "R:" & RaceInfo.id.RaceNum & _
                               "レース名:" & RaceInfo.RaceInfo.Ryakusyo10 & vbCrLf)
            ProgressBar.PerformStep()
        Next

    End Sub
    Private Function GetJVRace()
        Try
            Dim Races As New ArrayList
            Dim strBuff = New String(vbNullChar, 110000)
            Races = JVGet_common("stored", "RACE", "20150510000000", "1")

            Return Races
        Catch ex As Exception
            Return "Error"
        End Try
    End Function
    Private Function GetJVOdds()
        Try
            Dim strBuff = New String(vbNullChar, 110000)
            Dim arOdds As New ArrayList

            arOdds = JVGet_common("RT", "0B30", ListRace.SelectedItems.Item(0))
            Return arOdds

        Catch ex As Exception
            Return "Error"
        End Try
    End Function
    Private Sub btnGetJVOdds_Click(sender As Object, e As EventArgs) Handles btnGetJVOdds.Click
        Dim OddsInfo As JV_O1_ODDS_TANFUKUWAKU  'オッズ詳細情報構造体
        Dim arOdds As New ArrayList

        arOdds = GetJVOdds()
        OddsInfo = arOdds(0)

        For Each eachOdds In OddsInfo.OddsFukusyoInfo
            'データ表示
            rtbData.AppendText("馬番:" & eachOdds.Umaban & "/最高:" & eachOdds.OddsHigh & vbCrLf)
        Next
    End Sub
    Private Function JVGet_common(strDataType As String, strDataSpec As String, strFromTime As String, Optional lOption As Long = 0) As Object
        'strDataType: JVデータタイプ
        'strDataSpec: JVOpenファイル識別子
        'strFromTime: JVOpen データ提供日付
        'lOption: JVOpen オプション

        Dim objReturn As New ArrayList
        Dim IReturnCode As Long
        Try
            Dim lReadCount As Long      'JV Link戻り値
            Dim lDownloadCount As Long  'JV Open:総ダウンロードファイル数
            Dim strLastFileTimestamp As String 'JV Open:最新ファイルのタイムスタンプ
            Dim strErrMsg As String

            Const lBuffSize As Long = 110000    'JVRead:データ格納バッファサイズ
            Const lNameSize As Integer = 256    'JVRead:ファイル名サイズ
            Dim strBuff As String               'JVRead:データ格納バッファ
            Dim strFileName As String           'JVRead:ダウンロードファイル名

            Dim RaceInfo As JV_RA_RACE          'レース詳細情報構造体
            Dim OddsInfo As JV_O1_ODDS_TANFUKUWAKU  'オッズ詳細情報構造体

            If strDataType = "stored" Then
                'JV Link 蓄積型データダウンロード処理
                IReturnCode = Me.AxJVLink1.JVOpen(strDataSpec, strFromTime, lOption, lReadCount, lDownloadCount, strLastFileTimestamp)
                strErrMsg = "戻り値:" & IReturnCode & vbCrLf & "読み込みファイル数：" & lReadCount & vbCrLf & _
                        "ダウンロードファイル数：" & lDownloadCount & vbCrLf & "タイムスタンプ：" & strLastFileTimestamp
                ProgressBar.Value = Me.AxJVLink1.JVStatus()
                ProgressBar.Maximum = lDownloadCount
                ProgressBar.Minimum = 0
                ProgressBar.Step = 1
            Else
                'JV Link リアルタイムデータダウンロード処理
                IReturnCode = Me.AxJVLink1.JVRTOpen(strDataSpec, strFromTime)
                strErrMsg = "戻り値:" & IReturnCode
                lReadCount = 1
            End If

            If IReturnCode = 0 Then
                MsgBox(strErrMsg)

                If lReadCount > 0 Then
                    Do
                        'バッファ作成
                        strBuff = New String(vbNullChar, lBuffSize)
                        strFileName = New String(vbNullChar, lNameSize)
                        'JVReadで1行読み込み
                        IReturnCode = Me.AxJVLink1.JVRead(strBuff, lBuffSize, strFileName)


                        'リターンコード分岐
                        Select Case IReturnCode
                            Case 0  '全ファイル読み込み終了
                                Exit Do
                            Case -1 'ファイル切り替わり
                            Case -3 'ダウンロード中
                            Case -201 'JV Init未了
                                MsgBox("JV Initが行われていません。")
                                Exit Do
                            Case -203 'Openされていない
                                MsgBox("JVOpenが行われていません。")
                                Exit Do
                            Case -503  'ファイルが存在しない
                                MsgBox(strFileName & "が存在しません。")
                                Exit Do
                            Case Is > 0 '正常読み込み
                                'レコード種別IDの識別
                                Select Case Mid(strBuff, 1, 2)
                                    Case "RA"
                                        If strDataSpec = "RACE" Then
                                            RaceInfo.SetData(strBuff)
                                            objReturn.Add(RaceInfo)
                                        End If

                                    Case "O1"
                                        If strDataSpec = "0B30" Then
                                            OddsInfo.SetData(strBuff)
                                            objReturn.Add(OddsInfo)
                                        End If
                                End Select
                        End Select
                    Loop While (1)
                End If
            End If

        Catch ex As Exception
            Debug.WriteLine(Err.Description)
            Exit Function
        End Try

        'JV Link処理終了
        IReturnCode = Me.AxJVLink1.JVClose
        If IReturnCode <> 0 Then
            MsgBox("JVCloseエラー：" & IReturnCode)
        End If
        MsgBox("読み込み処理終了")
        Return objReturn
    End Function

End Class
