using Enfu.DAL.Core;
using EnFu.DAL.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace EnFu.DAL
{
    public class UnitOfWork : IDisposable
    {
        private DbContext _context;
        public UnitOfWork(DbContext context)
        {
            _context = context;
        }

        public bool Save()
        {
            var num = _context.SaveChanges();
            return num > 0;
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private GenericRepository<BibleReading> _bibleReadingRepository;
        private GenericRepository<Event> _eventRepository;
        private GenericRepository<SundayServe> _sundayServeRepository;
        private GenericRepository<WorshipSongServe> _worshipSongServeRepository;
        private GenericRepository<WorshipSongLyrics> _worshipSongLyricsRepository;
        private GenericRepository<Team> _teamRepository;
        private GenericRepository<WorkFlow> _workFlowRepository;
        private GenericRepository<PrayMatter> _prayMatterRepository;
        private GenericRepository<GroupMeeting> _groupMeetingRepository;
        private GenericRepository<Donate> _donateRepository;
        private GenericRepository<SpiritualEssay> _spiritualEssayRepository;

        private GenericRepository<CallChaptor> _callChaptorRepository;
        private GenericRepository<DonateBibleChaptor> _donateBibleChaptorRepository;
        private GenericRepository<BibleChaptor> _bibleChaptorRepository;
        private GenericRepository<BibleChaptorDetail> _bibleChaptorDetailRepository;
        private GenericRepository<BibleChaptorLink> _bibleChaptorLinkRepository;
        private GenericRepository<Post> _postRepository;
        private GenericRepository<PostContent> _postContentRepository;

        private GenericRepository<UserProfile> _userProfileRepository;

        public GenericRepository<BibleReading> BibleReadingRepository
        {
            get
            {
                return _bibleReadingRepository ?? new GenericRepository<BibleReading>(_context);
            }
        }

        public GenericRepository<Event> EventRepository
        {
            get
            {
                return _eventRepository ?? new GenericRepository<Event>(_context);
            }
        }
        public GenericRepository<SundayServe> SundayServeRepository
        {
            get
            {
                return _sundayServeRepository ?? new GenericRepository<SundayServe>(_context);
            }
        }
        public GenericRepository<WorshipSongServe> WorshipSongServeRepository
        {
            get
            {
                return _worshipSongServeRepository ?? new GenericRepository<WorshipSongServe>(_context);
            }
        }
        public GenericRepository<WorshipSongLyrics> WorshipSongLyricsRepository
        {
            get
            {
                return _worshipSongLyricsRepository ?? new GenericRepository<WorshipSongLyrics>(_context);
            }
        }
        public GenericRepository<Team> TeamRepository
        {
            get
            {
                return _teamRepository ?? new GenericRepository<Team>(_context);
            }
        }
        public GenericRepository<WorkFlow> WorkFlowRepository
        {
            get
            {
                return _workFlowRepository ?? new GenericRepository<WorkFlow>(_context);
            }
        }

        public GenericRepository<PrayMatter> PrayMatterRepository
        {
            get
            {
                return _prayMatterRepository ?? new GenericRepository<PrayMatter>(_context);
            }
        }

        public GenericRepository<GroupMeeting> GroupMeetingRepository
        {
            get
            {
                return _groupMeetingRepository ?? new GenericRepository<GroupMeeting>(_context);
            }
        }

        public GenericRepository<Donate> DonateRepository
        {
            get
            {
                return _donateRepository ?? new GenericRepository<Donate>(_context);
            }
        }
        public GenericRepository<SpiritualEssay> SpiritualEssayRepository
        {
            get
            {
                return _spiritualEssayRepository ?? new GenericRepository<SpiritualEssay>(_context);
            }
        }

        public GenericRepository<CallChaptor> CallChaptorRepository
        {
            get
            {
                return _callChaptorRepository ?? new GenericRepository<CallChaptor>(_context);
            }
        }

        public GenericRepository<DonateBibleChaptor> DonateBibleChaptorRepository
        {
            get
            {
                return _donateBibleChaptorRepository ?? new GenericRepository<DonateBibleChaptor>(_context);
            }
        }

        public GenericRepository<BibleChaptor> BibleChaptorRepository
        {
            get
            {
                return _bibleChaptorRepository ?? new GenericRepository<BibleChaptor>(_context);
            }
        }

        public GenericRepository<BibleChaptorDetail> BibleChaptorDetailRepository
        {
            get
            {
                return _bibleChaptorDetailRepository ?? new GenericRepository<BibleChaptorDetail>(_context);
            }
        }

        public GenericRepository<BibleChaptorLink> BibleChaptorLinkRepository
        {
            get
            {
                return _bibleChaptorLinkRepository ?? new GenericRepository<BibleChaptorLink>(_context);
            }
        }
        public GenericRepository<Post> PostRepository
        {
            get
            {
                return _postRepository ?? new GenericRepository<Post>(_context);
            }
        }
        public GenericRepository<PostContent> PostContentRepository
        {
            get
            {
                return _postContentRepository ?? new GenericRepository<PostContent>(_context);
            }
        }
        public GenericRepository<UserProfile> UserProfileRepository
        {
            get
            {
                return _userProfileRepository ?? new GenericRepository<UserProfile>(_context);
            }
        }
    }
}