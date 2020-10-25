 include 'path/to/mailin-api/Mailin.php';
                                        $mailin = new Mailin('Joshua.orrell@outlook.com', '401MXNLqRzbVCkGT');
                                        $mailin->
                                        addTo('Joshua.orrell@outlook.com', ' ')->
                                        setFrom('Joshua.orrell@outlook.com', ' ')->
                                        setReplyTo('Joshua.orrell@outlook.com',' ')->
                                        setSubject('Enter the subject here')->
                                        setText('Hello')->
                                        setHtml('<strong>Hello</strong>');
                                        $res = $mailin->send();
                                        /**
                                        Successful send message will be returned in this format:
                                        {'result' => true, 'message' => 'Email sent'}
                                        */