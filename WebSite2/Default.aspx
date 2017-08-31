<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>首頁</title>
    <link href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css" rel="stylesheet" />
</head>
<body>
    <!--<form id="form1" runat="server"></form>-->
    <div class="container">
        <div class="row">
            <div class="col-sm-3">
                <div id="treeview"></div>
            </div>
            <div class="col-sm-9">
                <iframe id="iframe_main" width="100%" height="500"></iframe>
            </div>
        </div>
    </div>

    <script src="https://code.jquery.com/jquery-3.2.1.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js"></script>
    <script src="src/js/bootstrap-treeview.js"></script>

    <script>
        var defaultData = [
            {
                text: 'Parent 1',
                href: '#parent1',
                tags: ['1'],
                nodes: [
                    {
                        text: 'Child 1',
                        href: '#child1',
                        tags: ['2'],
                        nodes: [
                            {
                                text: 'Grandchild 1',
                                href: '#grandchild1',
                                tags: ['0']
                            },
                            {
                                text: 'Grandchild 2',
                                href: '#grandchild2',
                                tags: ['0']
                            }
                        ]
                    },
                    {
                        text: 'Child 2',
                        href: '#child2',
                        tags: ['1', '1']
                    }
                ]
            },
            {
                text: 'Parent 2',
                href: '#parent2',
                tags: ['0'],
                node: []
            },
            {
                text: 'Parent 3',
                href: '#parent3',
                tags: ['0']
            },
            {
                text: 'Parent 4',
                href: '#parent4',
                tags: ['0']
            },
            {
                text: 'Parent 5',
                href: 'http://nchu.ddns.net',
                tags: ['0']

            }
        ];

        var defaultData = <%= json %>;
        $('#treeview').treeview({
            data: defaultData
        });

        $('#treeview').on('nodeSelected', function (event, data) {
            $('#iframe_main').attr('src', data.href);
        });

    </script>
</body>
</html>
