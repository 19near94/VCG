 $(document).ready(function () {
        $('#tblDivision').DataTable({
            "ajax": globalBaseURL + 'data.txt',
            "columns": [
                { "data": "conference" },
                { "data": "division" },
                { "data": "rank" },
                { "data": "full_name" },
                { "data": "city" },
                { "data": "coach" },
                { "data": "win-loss" },
                 { "data": "Player" }
            ]
        });


    });
